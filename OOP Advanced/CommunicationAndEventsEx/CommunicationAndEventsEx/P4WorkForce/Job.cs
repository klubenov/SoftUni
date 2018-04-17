using System;
using System.Collections.Generic;
using System.Text;
using P4WorkForce.Contracts;

namespace P4WorkForce
{
    public delegate bool JobDoneEventHandler(Job sender, EventArgs args);

    public class Job
    {
        public event JobDoneEventHandler JobDone;

        private IEmployable employee;

        private string name;

        private int hoursOfWorkRequired;

        public int HoursOfWorkRequired
        {
            get { return this.hoursOfWorkRequired; }
            private set { hoursOfWorkRequired = Math.Max(0, value); }
        }

        public Job(string name, int hoursOfWorkRequired, IEmployable employee)
        {
            this.name = name;
            this.HoursOfWorkRequired = hoursOfWorkRequired;
            this.employee = employee;
        }

        public bool Update(EventArgs args)
        {
            this.HoursOfWorkRequired -= this.employee.WorkHoursPerWeek;
            bool isCompleted = false;
            if (this.HoursOfWorkRequired==0)
            {
                Console.WriteLine($"{this.GetType().Name} {this.name} done!");
                isCompleted = this.JobDone(this,args);
            }
            return isCompleted;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.name} Hours Remaining: {this.HoursOfWorkRequired}";
        }
    }
}
