using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using Exam.App.BindingModels;
using Exam.App.Controllers.Base;
using Exam.App.ViewModels;
using Exam.Data;
using Exam.Models;
using Exam.Models.Enums;
using Microsoft.EntityFrameworkCore;
using SIS.Framework.ActionResults;
using SIS.Framework.Attributes.Action;
using SIS.Framework.Attributes.Method;

namespace Exam.App.Controllers
{
    public class PackagesController : BaseController
    {
        public PackagesController(ExamDbContext context)
            : base(context)
        {

        }

        [Authorize("Admin")]
        public IActionResult Create()
        {
            var users = this.context.Users.Select(u => new UsersCreatePackageViewModel
            {
                Username = u.Username
            }).ToArray();

            this.Model.Data["Users"] = users;

            return this.View();
        }

        [Authorize("Admin")]
        [HttpPost]
        public IActionResult Create(CreatePackageBindingModel bindingModel)
        {
            var recipient = this.context.Users.FirstOrDefault(u => u.Username == bindingModel.Recipient);

            if (recipient == null)
            {
                return this.View();
            }

            var package = new Package
            {
                Description = bindingModel.Description,
                Recipient = recipient,
                EstimatedDeliveryDate = null,
                ShippingAddress = bindingModel.ShippingAddress,
                Weight = double.Parse(bindingModel.Weight)
            };

            this.context.Add(package);
            this.context.SaveChanges();

            return this.RedirectToAction("/");
        }

        [Authorize]
        public IActionResult Details()
        {
            var packageId = int.Parse(this.Request.QueryData["id"].ToString());

            var package = this.context.Packages.Include(p => p.Recipient).FirstOrDefault(p => p.Id == packageId);

            if (package == null)
            {
                return this.RedirectToAction("/");
            }

            var estDeliveryDate = string.Empty;

            if (package.Status == Status.Pending)
            {
                estDeliveryDate = "N/A";
            }
            else if (package.Status == Status.Shipped)
            {
                estDeliveryDate = package.EstimatedDeliveryDate.Value.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
            }
            else
            {
                estDeliveryDate = "Delivered";
            }

            var packageViewModel = new PackageDetailsViewModel
            {
                Address = package.ShippingAddress,
                Description = package.Description,
                EstimatedDeliveryDate = estDeliveryDate,
                Recipient = package.Recipient.Username,
                Status = package.Status.ToString(),
                Weight = package.Weight.ToString()
            };

            this.Model.Data["PackageDetails"] = packageViewModel;

            return this.View();
        }

        [Authorize("Admin")]
        public IActionResult Pending()
        {
            var pendingPackages = this.context.Packages.Include(p => p.Recipient)
                .Where(p => p.Status == Status.Pending)
                .Select(p => new PackagePendingViewModel
                {
                    Description = p.Description,
                    Id = p.Id.ToString(),
                    Recipient = p.Recipient.Username,
                    ShippingAddress = p.ShippingAddress,
                    Weight = p.Weight.ToString()
                }).ToArray();

            this.Model.Data["PendingDetailsViewModels"] = pendingPackages;

            return this.View();
        }

        [Authorize("Admin")]
        public IActionResult Shipped()
        {
            var shippedPackages = this.context.Packages.Include(p => p.Recipient)
                .Where(p => p.Status == Status.Shipped)
                .Select(p => new PackagesShippedViewModel
                {
                    Description = p.Description,
                    Id = p.Id.ToString(),
                    Recipient = p.Recipient.Username,
                    ShippingAddress = p.ShippingAddress,
                    Weight = p.Weight.ToString()
                }).ToArray();

            this.Model.Data["ShippedDetailsViewModels"] = shippedPackages;

            return this.View();
        }

        [Authorize("Admin")]
        public IActionResult Delivered()
        {
            var deliveredPackages = this.context.Packages.Include(p => p.Recipient)
                .Where(p => p.Status == Status.Delivered || p.Status == Status.Acquired)
                .Select(p => new PackageDeliveredViewModel
                {
                    Description = p.Description,
                    Id = p.Id.ToString(),
                    Recipient = p.Recipient.Username,
                    ShippingAddress = p.ShippingAddress,
                    Weight = p.Weight.ToString()
                }).ToArray();

            this.Model.Data["DeliveredDetailsViewModels"] = deliveredPackages;

            return this.View();
        }

        [Authorize("Admin")]
        public IActionResult Ship()
        {
            var packageId = int.Parse(this.Request.QueryData["id"].ToString());

            var package = this.context.Packages.FirstOrDefault(p => p.Id == packageId);

            if (package == null)
            {
                return this.RedirectToAction("/");
            }

            var random = new Random();

            var daysForDelivery = random.Next(20,40);

            var estimatedDeliveryDate = DateTime.Now.AddDays(daysForDelivery);

            package.Status = Status.Shipped;
            package.EstimatedDeliveryDate = estimatedDeliveryDate;

            context.SaveChanges();

            return this.RedirectToAction("/Packages/Pending");
        }

        [Authorize("Admin")]
        public IActionResult Deliver()
        {
            var packageId = int.Parse(this.Request.QueryData["id"].ToString());

            var package = this.context.Packages.FirstOrDefault(p => p.Id == packageId);

            if (package == null)
            {
                return this.RedirectToAction("/");
            }

            package.Status = Status.Delivered;
            context.SaveChanges();

            return this.RedirectToAction("/Packages/Shipped");
        }

        [Authorize]
        public IActionResult Acquire()
        {
            var packageId = int.Parse(this.Request.QueryData["id"].ToString());

            var package = this.context.Packages.Include(p => p.Recipient).FirstOrDefault(p => p.Id == packageId);

            package.Status = Status.Acquired;

            var recepit = new Receipt
            {
                Fee = (decimal)(package.Weight * 2.67),
                IssuedOn = DateTime.Now,
                PackageId = package.Id,
                RecipientId = package.RecipientId
            };

            context.Receipts.Add(recepit);
            context.SaveChanges();

            return RedirectToAction("/");
        }
    }
}
