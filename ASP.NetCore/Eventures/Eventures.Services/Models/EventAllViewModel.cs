using System.Collections.Generic;
using System.Linq;
using Eventures.Services.Shared;

namespace Eventures.Services.Models
{
    using System;

    public class EventAllViewModel
    {
        public IEnumerable<EventViewModel> Events { get; set; }

        public int CurrentPage { get; set; }

        public int TotalPages { get; set; }
    }
}
