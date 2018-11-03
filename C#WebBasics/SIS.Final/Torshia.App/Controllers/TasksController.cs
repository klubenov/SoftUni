using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SIS.Framework.ActionResults;
using SIS.Framework.Attributes.Method;
using Torshia.App.Controllers.Base;
using Torshia.App.ViewModels.Tasks;
using Torshia.Models;
using Torshia.Models.Enums;

namespace Torshia.App.Controllers
{
    public class TasksController : BaseController
    {
        public IActionResult Create()
        {
            if (this.Identity == null)
            {
                return this.RedirectToAction("/users/login");
            }
            else if (this.Identity.Roles.First() != "Admin")
            {
                this.ErrorMessage = "Only logged Admin can create tasks!";
                return this.View();
            }
            else
            {
                return this.View();
            }
        }

        [HttpPost]
        public IActionResult Create(CreateTaskViewModel createViewModel)
        {
            var title = createViewModel.Title;

            var dueDate = DateTime.ParseExact(createViewModel.DueDate, "yyyy-MM-dd", CultureInfo.InvariantCulture);

            var description = createViewModel.Description;
            var participants = createViewModel.Participants.Replace("%2C+", ", ");

            //var random = new Random();
            //var probability = 0.75;

            //var isTaskReported = random.NextDouble() >= probability;
            var isTaskReported = false;


            var task = new Task
            {
                Title = title,
                DueDate = dueDate,
                Description = description,
                Participants = participants,
                IsReported = isTaskReported
            };

            var taskSectors = new List<TaskSector>();

            var affectedSectors = new List<string>()
            {
                createViewModel.Customers,
                createViewModel.Finances,
                createViewModel.Internal,
                createViewModel.Management,
                createViewModel.Marketing
            };

            foreach (var affectedSector in affectedSectors)
            {
                if (affectedSector != null)
                {
                    var sector = context.Sectors.FirstOrDefault(s => s.Name == affectedSector);

                    if (sector == null)
                    {
                        sector = new Sector
                        {
                            Name = affectedSector
                        };
                    }

                    taskSectors.Add(new TaskSector
                    {
                        Task = task,
                        Sector = sector
                    });
                }
            }

            context.Tasks.Add(task);
            context.TaskSectors.AddRange(taskSectors);
            context.SaveChanges();

            return this.RedirectToAction("/");
        }

        public IActionResult Details()
        {
            var taskId = int.Parse(this.Request.QueryData["id"].ToString());

            var task = this.context.Tasks.Include(t => t.TasksSectors).ThenInclude(ts => ts.Sector).FirstOrDefault(t => t.Id == taskId);

            if (task == null)
            {
                return this.RedirectToAction("/");
            }

            var affectedSectorsNames = string.Join(", ", task.TasksSectors.Select(ts => ts.Sector.Name));

            var detailsTaskViewModel = new DetailsTaskViewModel
            {
                Title = task.Title,
                Description = task.Description,
                AffectedSectors = affectedSectorsNames,
                DueDate = task.DueDate.ToString("dd/MM/yyyy"),
                Participants = task.Participants,
                Level = task.TasksSectors.Count.ToString()
            };

            this.Model.Data["TaskDetails"] = detailsTaskViewModel;

            return this.View();
        }

        public IActionResult Report()
        {
            if (this.Identity == null)
            {
                return this.RedirectToAction("/");
            }

            var taskId = int.Parse(this.Request.QueryData["id"].ToString());

            var task = this.context.Tasks.FirstOrDefault(t => t.Id == taskId);

            if (task == null)
            {
                return this.RedirectToAction("/");
            }

            var random = new Random();
            var probability = 0.75;

            var isReportCompleted = random.NextDouble() < probability;
            var status = Status.Completed;
            if (!isReportCompleted)
            {
                status = Status.Archived;
            }

            var report = new Report
            {
                Status = status,
                ReportedOn = DateTime.Now,
                Reporter = this.context.Users.FirstOrDefault(u => u.Username == this.Identity.Username),
                TaskId = task.Id
            };

            task.IsReported = true;

            this.context.Reports.Add(report);
            this.context.SaveChanges();

            return this.RedirectToAction("/");
        }
    }
}
