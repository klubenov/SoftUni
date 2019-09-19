using System;
using System.Collections.Generic;
using System.Text;

namespace Exam.App.ViewModels
{
    public class ReceiptDetailsViewModel
    {
        public string Id { get; set; }

        public string IssuedOn { get; set; }

        public string DeliveryAddress { get; set; }

        public string Weight { get; set; }

        public string PackageDescription { get; set; }

        public string Recipient { get; set; }

        public string Fee { get; set; }
    }
}
