using System;
using System.Collections.Generic;
using System.Text;


class Company
{
    public string Name { get; set; }

    public string Department { get; set; }

    public decimal Salary { get; set; }

    public Company()
    {
        
    }

    public override string ToString()
    {
        if (Name != null)
        {
            return $"{Name} {Department} {Salary:f2}\r\n";
        }
        else
        {
            return null;
        }
    }
}

