using System.Linq;
using Microsoft.EntityFrameworkCore;
using SIS.Framework.ActionResults;
using Torshia.App.Controllers.Base;
using Torshia.App.ViewModels.Reports;

namespace Torshia.App.Controllers
{
    public class ReportsController : BaseController
    {
        public IActionResult All()
        {
            if (this.Identity == null)
            {
                return this.RedirectToAction("/users/login");
            }

            if (this.Identity.Roles.First() != "Admin")
            {
                return this.RedirectToAction("/");
            }

            var reportAllViewModels = this.context.Reports.Select(r => new ReportAllViewModel
            {
                ReportId = r.Id.ToString(),
                Status = r.Status.ToString(),
                TaskLevel = r.Task.TasksSectors.Count.ToString(),
                TaskTitle = r.Task.Title
            }).ToList();

            for (int i = 1; i <= reportAllViewModels.Count(); i++)
            {
                reportAllViewModels[i-1].OrderNumber = i.ToString();
            }

            this.Model.Data["ReportAllViewModels"] = reportAllViewModels;

            return this.View();
        }

        public IActionResult Details()
        {
            if (this.Identity == null)
            {
                return this.RedirectToAction("/users/login");
            }

            if (this.Identity.Roles.First() != "Admin")
            {
                return this.RedirectToAction("/");
            }

            var reportId = int.Parse(this.Request.QueryData["id"].ToString());

            var reportDetailsViewModel = this.context.Reports.Select(r => new ReportDetailsViewModel
            {
                ReportId = r.Id.ToString(),
                TaskTitle = r.Task.Title,
                TaskLevel = r.Task.TasksSectors.Count.ToString(),
                Status = r.Status.ToString(),
                TaskDueDate = r.Task.DueDate.ToString("dd/MM/yyyy"),
                ReportedOn = r.ReportedOn.ToString("dd/MM/yyyy"),
                Reporter = r.Reporter.Username,
                TaskParticipants = r.Task.Participants,
                AffectedSectors = string.Join(", ", r.Task.TasksSectors.Select(ts => ts.Sector.Name)),
                TaskDescription = r.Task.Description
            }).FirstOrDefault(r => r.ReportId == reportId.ToString());

            this.Model.Data["ReportDetails"] = reportDetailsViewModel;

            return this.View();
        }
    }
}
