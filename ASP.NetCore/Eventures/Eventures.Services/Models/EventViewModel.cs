using System;
using System.Collections.Generic;
using System.Text;

namespace Eventures.Services.Models
{
    public class EventViewModel
    {
        public int Number { get; set; }

        public string Name { get; set; }

        public int TicketsRemaining { get; set; }

        public DateTime Start { get; set; }

        public DateTime End { get; set; }
    }
}
