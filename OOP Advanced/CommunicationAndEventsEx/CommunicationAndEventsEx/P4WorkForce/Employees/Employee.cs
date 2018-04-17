using System;
using System.Collections.Generic;
using System.Text;
using P4WorkForce.Contracts;

namespace P4WorkForce.Employees
{
    public abstract class Employee : IEmployable
    {
        public string Name { get; }

        public int WorkHoursPerWeek { get; }

        protected Employee(string name, int workHoursPerWeek)
        {
            this.Name = name;
            this.WorkHoursPerWeek = workHoursPerWeek;;
        }
    }
}
