using System;
using System.Collections.Generic;
using System.Text;


public class PressureProvider : Provider
{
    public PressureProvider(string id, double energyOutput) : base(id, energyOutput*1.5)
    {
        this.Type = "Pressure";
    }

    public override string ToString()
    {
        return $"{this.Type} {base.GetType().BaseType.Name} - {base.ToString()}";
    }
}

