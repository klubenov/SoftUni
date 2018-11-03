using System.Collections.Generic;

namespace Torshia.Models
{
    public class Sector
    {
        public Sector()
        {
            this.TasksSectors = new HashSet<TaskSector>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<TaskSector> TasksSectors { get; set; }
    }
}
