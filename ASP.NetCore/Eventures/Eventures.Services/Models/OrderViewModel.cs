using System;
using System.Collections.Generic;
using System.Text;

namespace Eventures.Services.Models
{
    public class OrderViewModel
    {
        public string EventName { get; set; }

        public string CustomerName { get; set; }

        public DateTime OrderedOn { get; set; }
    }
}
