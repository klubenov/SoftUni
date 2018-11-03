using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Microsoft.EntityFrameworkCore;
using SIS.Framework.ActionResults;
using SIS.Framework.Controllers;
using Torshia.Data;

namespace Torshia.App.Controllers.Base
{
    public class BaseController : Controller
    {
        protected TorshiaDbContext context;

        protected string ErrorMessage { get; set; }

        public BaseController()
        {
            this.ErrorMessage = "";
            this.context = new TorshiaDbContext();
        }

        protected override IViewable View([CallerMemberName]string actionName = "")
        {
            this.Model.Data["ErrorMessage"] = this.ErrorMessage;

            if (this.Identity == null)
            {
                this.Model.Data["NotLoggedIn"] = "block";
                this.Model.Data["UserLoggedIn"] = "none";
                this.Model.Data["AdminLoggedIn"] = "none";
            }
            else
            {
                if (this.Identity.Roles.First() == "User")
                {
                    this.Model.Data["NotLoggedIn"] = "none";
                    this.Model.Data["UserLoggedIn"] = "block";
                    this.Model.Data["AdminLoggedIn"] = "none";
                }
                else
                {
                    this.Model.Data["NotLoggedIn"] = "none";
                    this.Model.Data["UserLoggedIn"] = "none";
                    this.Model.Data["AdminLoggedIn"] = "block";
                }
            }

            return base.View(actionName);
        }
    }
}
