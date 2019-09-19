using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using Exam.App.Controllers.Base;
using Exam.App.ViewModels;
using Exam.Data;
using Microsoft.EntityFrameworkCore;
using SIS.Framework.ActionResults;
using SIS.Framework.Attributes.Action;

namespace Exam.App.Controllers
{
    class ReceiptsController : BaseController
    {
        public ReceiptsController(ExamDbContext context)
            : base(context)
        {

        }

        [Authorize]
        public IActionResult Index()
        {
            var receiptIndexViewModels = context.Receipts.Include(r => r.Recipient)
                .Where(r => r.Recipient.Username == this.Identity.Username)
                .Select(r => new ReceiptIndexViewModel
                {
                    Fee = r.Fee.ToString("F2"),
                    Id = r.Id.ToString(),
                    IssuedOn = r.IssuedOn.ToString(),
                    Recipient = r.Recipient.Username
                }).ToArray();

            this.Model.Data["ReceiptIndexViewModel"] = receiptIndexViewModels;

            return this.View();
        }

        [Authorize]
        public IActionResult Details()
        {
            var receiptId = int.Parse(this.Request.QueryData["id"].ToString());

            var receiptViewModel = context.Receipts.Include(r => r.Recipient).Include(r => r.Package)
                .Where(r => r.Id == receiptId)
                .Select(r => new ReceiptDetailsViewModel
                {
                    DeliveryAddress = r.Package.ShippingAddress,
                    Fee = r.Fee.ToString("F2"),
                    Id = r.Id.ToString(),
                    IssuedOn = r.IssuedOn.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture),
                    PackageDescription = r.Package.Description,
                    Recipient = r.Recipient.Username,
                    Weight = r.Package.Weight.ToString()
                }).FirstOrDefault();

            this.Model.Data["ReceiptDetails"] = receiptViewModel;

            return this.View();
        }
    }
}
