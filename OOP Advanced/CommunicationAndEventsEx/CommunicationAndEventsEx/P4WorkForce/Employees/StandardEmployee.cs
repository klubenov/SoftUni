using System;
using System.Collections.Generic;
using System.Text;
using P4WorkForce.Contracts;

namespace P4WorkForce.Employees
{
    public class StandardEmployee : Employee
    {
        public StandardEmployee(string name) : base(name, 40)
        {

        }
    }
}
