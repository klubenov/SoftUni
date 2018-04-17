using System;
using System.Collections.Generic;
using System.Text;

namespace P4WorkForce.Contracts
{
    public interface IEmployable
    {
        string Name { get; }

        int WorkHoursPerWeek { get; }
    }
}
