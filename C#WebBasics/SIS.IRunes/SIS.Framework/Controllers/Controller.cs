using System.Runtime.CompilerServices;
using SIS.Framework.ActionResults;
using SIS.Framework.ActionResults.Contracts;
using SIS.Framework.Models;
using SIS.Framework.Security;
using SIS.Framework.Utilities;
using SIS.Framework.Views;
using SIS.HTTP.Requests;

namespace SIS.Framework.Controllers
{
    public abstract class Controller
    {
        protected Controller()
        {
            this.Model = new ViewModel();
        }

        protected ViewModel Model { get; }

        public Model ModelState { get; } = new Model();

        public IHttpRequest Request { get; set; }

        public IIdentity Identity
            => this.Request.Session.ContainsParameter("auth")
                ? (IIdentity)this.Request.Session.GetParameter("auth")
                : null;

        protected IViewable View([CallerMemberName] string viewName = "")
        {
            var controllerName = ControllerUtilities.GetControllerName(this);

            var fullyQualifiedName = ControllerUtilities.GetViewFullyQualifiedName(controllerName, viewName);

            var view = new View(fullyQualifiedName, this.Model.Data);

            return new ViewResult(view);
        }

        protected IRedirectable RedirectToAction(string redirectUrl)
        {
            return new RedirectResult(redirectUrl);
        }

        protected void SignIn(IIdentity auth)
        {
            this.Request.Session.AddParameter("auth", auth);
        }

        protected void SignOut()
        {
            this.Request.Session.ClearParameters();
        }
    }
}
