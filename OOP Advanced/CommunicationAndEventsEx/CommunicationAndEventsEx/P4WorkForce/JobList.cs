using System;
using System.Collections.Generic;
using System.Text;

namespace P4WorkForce
{
    public class JobList<Job>:List<Job>
    {
        public bool OnJobUpdate(Job sender, EventArgs args)
        {
            return this.Remove(sender);
        }
    }
}
