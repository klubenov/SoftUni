using System;
using System.Collections.Generic;
using System.Text;

namespace Torshia.App.ViewModels.Tasks
{
    public class DetailsTaskViewModel
    {
        public string Title { get; set; }

        public string Participants { get; set; }

        public string DueDate { get; set; }

        public string AffectedSectors { get; set; }

        public string Description { get; set; }

        public string Level { get; set; }
    }
}
