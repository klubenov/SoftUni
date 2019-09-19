using System.Linq;
using System.Runtime.CompilerServices;
using Exam.Data;
using SIS.Framework.ActionResults;
using SIS.Framework.Controllers;

namespace Exam.App.Controllers.Base
{
    public class BaseController : Controller
    {
        protected ExamDbContext context;

        public BaseController(ExamDbContext context)
        {
            this.context = context;
        }

        protected override IViewable View([CallerMemberName]string actionName = "")
        {
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
