using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using SIS.Framework.ActionResults.Base;
using SIS.Framework.ActionResults.Contracts;
using SIS.Framework.Attributes.Contracts;
using SIS.Framework.Controllers;
using SIS.Framework.Services.Contracts;
using SIS.HTTP.Enums;
using SIS.HTTP.Exceptions;
using SIS.HTTP.Extensions;
using SIS.HTTP.Requests;
using SIS.HTTP.Responses;
using SIS.WebServer.Api.Contracts;
using SIS.WebServer.Results;

namespace SIS.Framework.Routers
{
    public class ControllerRouter : IHttpHandler
    {
        private readonly IDependencyContainer dependencyContainer;

        public ControllerRouter(IDependencyContainer dependencyContainer)
        {
            this.dependencyContainer = dependencyContainer;
        }

        private Controller GetController(string controllerName, IHttpRequest request)
        {
            if (controllerName != null)
            {
                string controllerTypeName = string.Format(
                    "{0}.{1}.{2}{3}, {0}",
                    MvcContext.Get.AssemblyName,
                    MvcContext.Get.ControllersFolder,
                    controllerName,
                    MvcContext.Get.ControllersSuffix);

                var controllerType = Type.GetType(controllerTypeName);
                var controller = (Controller) this.dependencyContainer.CreateInstance(controllerType);

                if (controller != null)
                {
                    controller.Request = request;
                }

                return controller;
            }

            return null;
        }

        private MethodInfo GetMethod(string requestMethod, Controller controller, string actionName)
        {
            MethodInfo method = null;

            foreach (var methodInfo in GetSuitableMethods(controller, actionName))
            {
                var attributes = methodInfo
                    .GetCustomAttributes()
                    .Where(attr => attr is HttpMethodAttribute)
                    .Cast<HttpMethodAttribute>();

                if (!attributes.Any() && requestMethod.ToUpper() == "GET")
                {
                    return methodInfo;
                }

                foreach (var attribute in attributes)
                {
                    if (attribute.IsValid(requestMethod))
                    {
                        return methodInfo;
                    }
                }
            }

            return method;
        }

        private IEnumerable<MethodInfo> GetSuitableMethods(Controller controller, string actionName)
        {
            if (controller == null)
            {
                return new MethodInfo[0];
            }

            return controller
                .GetType()
                .GetMethods()
                .Where(methodInfo => methodInfo.Name.ToLower() == actionName.ToLower());
        }

        private IHttpResponse PrepareResponse(IActionResult actionResult)
        {
            string invocationResult = actionResult.Invoke();

            if (actionResult is IViewable)
            {
                return new HtmlResult(invocationResult, HttpResponseStatusCode.Ok);
            }

            if (actionResult is IRedirectable)
            {
                return new RedirectResult(invocationResult);
            }

            throw new InvalidOperationException("The view result is not supported");

        }

        public IHttpResponse Handle(IHttpRequest request)
        {
            var controllerName = string.Empty;
            var actionName = string.Empty;
            var requestMethod = request.RequestMethod.ToString();

            if (request.Url == "/")
            {
                controllerName = "Home";
                actionName = "Index";
            }
            else
            {
                var requestSplitUrl = request.Url.Split("/", StringSplitOptions.RemoveEmptyEntries);

                controllerName = requestSplitUrl[0].Capitalize();
                actionName = requestSplitUrl[1].Capitalize();
            }

            var controller = GetController(controllerName, request);
            var action = GetMethod(requestMethod, controller, actionName);

            if (controller == null || action == null)
            {
                return new HttpResponse(HttpResponseStatusCode.NotFound);
            }

            object[] actionParameters = this.MapActionParameters(action, request, controller);

            IActionResult actionResult = this.InvokeAction(controller, action, actionParameters);
            return this.PrepareResponse(actionResult);
        }

        private IActionResult InvokeAction(Controller controller, MethodInfo action, object[] actionParameters)
        {
            return (IActionResult)action.Invoke(controller, actionParameters);
        }

        private object[] MapActionParameters(MethodInfo action, IHttpRequest httpRequest, Controller controller)
        {
            ParameterInfo[] actionParametersInfo = action.GetParameters();
            object[] mappedActionParameters = new object[actionParametersInfo.Length];

            for (int index = 0; index < actionParametersInfo.Length; index++)
            {
                ParameterInfo currentParameterInfo = actionParametersInfo[index];

                if (currentParameterInfo.ParameterType.IsPrimitive
                    || currentParameterInfo.ParameterType == typeof(string))
                {
                    mappedActionParameters[index] = ProcessPrimitiveParameter(currentParameterInfo, httpRequest);
                }
                else
                {
                    object bindingModel = ProcessBindingModelParameter(currentParameterInfo, httpRequest);
                    controller.ModelState.IsValid = this.IsValidModel(bindingModel, currentParameterInfo.ParameterType);
                    mappedActionParameters[index] = bindingModel;
                }
            }

            return mappedActionParameters;
        }

        private bool? IsValidModel(object bindingModel, Type bindingModelType)
        {
            var properties = bindingModelType.GetProperties();

            foreach (var property in properties)
            {
                var propertyValidationAttributes = property
                    .GetCustomAttributes()
                    .Where(pa => pa is ValidationAttribute)
                    .Cast<ValidationAttribute>()
                    .ToList();

                foreach (var validationAttribute in propertyValidationAttributes)
                {
                    var propertyValue = property.GetValue(bindingModel);

                    if (!validationAttribute.IsValid(propertyValue))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        private object ProcessBindingModelParameter(ParameterInfo param, IHttpRequest httpRequest)
        {
            Type bindingModelType = param.ParameterType;

            var bindingModelInstance = Activator.CreateInstance(bindingModelType);
            var bindingModelProperties = bindingModelType.GetProperties();

            foreach (var property in bindingModelProperties)
            {
                try
                {
                    object value = this.GetParameterFromRequestData(httpRequest, property.Name);
                    property.SetValue(bindingModelInstance, Convert.ChangeType(value, property.PropertyType));
                }
                catch
                {
                    Console.WriteLine($"The {property.Name} field could not be mapped.");
                }
            }

            return Convert.ChangeType(bindingModelInstance, bindingModelType);
        }

        private object ProcessPrimitiveParameter(ParameterInfo param, IHttpRequest httpRequest)
        {
            object value = this.GetParameterFromRequestData(httpRequest, param.Name);
            return Convert.ChangeType(value, param.ParameterType);
        }

        private object GetParameterFromRequestData(IHttpRequest httpRequest, string paramName)
        {
            if (httpRequest.QueryData.ContainsKey(paramName))
            {
                return httpRequest.QueryData[paramName];
            }

            if (httpRequest.FormData.ContainsKey(paramName))
            {
                return httpRequest.FormData[paramName];
            }

            return null;
        }
    }
}
