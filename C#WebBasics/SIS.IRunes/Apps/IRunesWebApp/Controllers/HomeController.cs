using System;
using Services;
using SIS.Framework.ActionResults.Base;
using SIS.Framework.Controllers;
using SIS.HTTP.Enums;
using SIS.HTTP.Requests;
using SIS.HTTP.Responses;
using SIS.WebServer.Results;

namespace IRunesWebApp.Controllers
{
    public class HomeController : Controller
    {
        //public IHttpResponse Index(IHttpRequest request)
        //{
        //    if (this.IsAuthenticated(request))
        //    {
        //        var username = request.Session.GetParameter("username");
        //        this.ViewBag["username"] = username.ToString();

        //        return this.View("IndexLoggedIn");
        //    }

        //    return this.View();
        //}
        public IActionResult Index()
        {

            return this.View();
        }
    }
}
