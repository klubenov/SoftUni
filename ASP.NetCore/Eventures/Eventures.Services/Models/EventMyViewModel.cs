using System;
using System.Collections.Generic;
using System.Text;

namespace Eventures.Services.Models
{
    public class EventMyViewModel
    {
        public int Number { get; set; }

        public string Name { get; set; }

        public DateTime Start { get; set; }

        public DateTime End { get; set; }

        public int Tickets { get; set; }
    }
}
