using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using Microsoft.EntityFrameworkCore;
using SIS.Framework.ActionResults;
using Torshia.App.Controllers.Base;
using Torshia.App.ViewModels.Tasks;

namespace Torshia.App.Controllers
{
    public class HomeController : BaseController
    {
        public IActionResult Index()
        {
            var tasks = context.Tasks.Include(t => t.TasksSectors).Where(t => t.IsReported == false).ToArray();

            var homeTaskViewModels = new List<HomeTaskViewModel>();

            foreach (var task in tasks)
            {
                homeTaskViewModels.Add(new HomeTaskViewModel
                {
                    Title = task.Title,
                    Level = task.TasksSectors.Count.ToString(),
                    Id = task.Id.ToString()
                    
                });
            }

            this.Model.Data["HomeTaskViewModels"] = homeTaskViewModels;
            if (this.Identity != null)
            {
                this.Model.Data["Username"] = this.Identity.Username;
            }

            return this.View();
        }
    }
}
