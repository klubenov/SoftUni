using System;
using System.Collections.Generic;
using System.Text;

namespace Exam.App.BindingModels
{
    public class CreatePackageBindingModel
    {
        public string Description { get; set; }

        public string Weight { get; set; }

        public string ShippingAddress { get; set; }

        public string Recipient { get; set; }
    }
}
