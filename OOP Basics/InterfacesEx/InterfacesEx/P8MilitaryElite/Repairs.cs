using System;
using System.Collections.Generic;
using System.Text;


public class Repairs
{
    public string PartName { get; private set; }

    public int HoursWorked { get; private set; }

    public Repairs(string partName, int hoursWorked)
    {
        PartName = partName;
        HoursWorked = hoursWorked;
    }

    public override string ToString()
    {
        return $"Part Name: {PartName} Hours Worked: {HoursWorked}";
    }
}

