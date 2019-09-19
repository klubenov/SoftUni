using System.Linq;
using Exam.App.Controllers.Base;
using Exam.App.ViewModels;
using Exam.Data;
using Exam.Models.Enums;
using SIS.Framework.ActionResults;

namespace Exam.App.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(ExamDbContext context)
            :base(context)
        {
            
        }
        public IActionResult Index()
        {
            if (this.Identity != null)
            {
                this.Model.Data["Username"] = this.Identity.Username;

                var pendindPackages = this.context.Packages
                    .Where(p => p.Status == Status.Pending && p.Recipient.Username == this.Identity.Username)
                    .Select(p =>
                    new HomePackageViewModel
                    {
                        Description = p.Description,
                        Id = p.Id
                    });

                var shippedPackages = this.context.Packages
                    .Where(p => p.Status == Status.Shipped && p.Recipient.Username == this.Identity.Username)
                    .Select(p =>
                        new HomePackageViewModel
                        {
                            Description = p.Description,
                            Id = p.Id
                        });

                var deliveredPackages = this.context.Packages
                    .Where(p => p.Status == Status.Delivered && p.Recipient.Username == this.Identity.Username)
                    .Select(p =>
                        new DeliverPackageViewModel
                        {
                            Description = p.Description,
                            Id = p.Id
                        });

                this.Model.Data["PendingViewModels"] = pendindPackages;
                this.Model.Data["ShippedViewModels"] = shippedPackages;
                this.Model.Data["DeliveredViewModels"] = deliveredPackages;
            }


            return this.View();
        }
    }
}
