using System;
using System.Linq;
using SIS.HTTP.Common;
using SIS.HTTP.Requests;
using SIS.HTTP.Responses;
using SIS.WebServer.Api.Contracts;

namespace SIS.Framework.Routers
{
    public class HttpRouteHandlingContext : IHttpHandlersContext
    {
        public HttpRouteHandlingContext(IHttpHandler controllerHandler, IHttpHandler resourceHandler)
        {
            this.ControllerHandler = controllerHandler;
            this.ResourceHandler = resourceHandler;
        }

        private IHttpHandler ControllerHandler { get; }

        private IHttpHandler ResourceHandler { get; }

        public IHttpResponse Handle(IHttpRequest request)
        {
            if (this.IsResourceRequest(request))
            {
                return this.ResourceHandler.Handle(request);
            }

            return this.ControllerHandler.Handle(request);
        }

        private bool IsResourceRequest(IHttpRequest httpRequest)
        {
            var requestPath = httpRequest.Path;
            if (requestPath.Contains('.'))
            {
                var requestPathExtension = requestPath
                    .Substring(requestPath.LastIndexOf('.'));
                return GlobalConstants.ResourceExtensions.Contains(requestPathExtension);
            }
            return false;
        }
    }
}
