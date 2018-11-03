using System;
using System.Collections.Generic;
using Torshia.Models.Enums;

namespace Torshia.Models
{
    public class Task
    {
        public Task()
        {
            this.TasksSectors = new HashSet<TaskSector>();
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public DateTime DueDate { get; set; }

        public bool IsReported { get; set; }

        public string Description { get; set; }

        public string Participants { get; set; }

        public ICollection<TaskSector> TasksSectors { get; set; }
    }
}
