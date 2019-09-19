using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Eventures.Services.Models
{
    public class OrderBindingModel
    {
        public int TicketsCount { get; set; }

        public string EventName { get; set; }

        public int AvailableTickets { get; set; }
    }
}
