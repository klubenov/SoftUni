using System;
using System.Collections.Generic;
using System.Text;

namespace Exam.App.ViewModels
{
    public class PackagesShippedViewModel
    {
        public string Id { get; set; }

        public string Description { get; set; }

        public string Weight { get; set; }

        public string ShippingAddress { get; set; }

        public string Recipient { get; set; }
    }
}
