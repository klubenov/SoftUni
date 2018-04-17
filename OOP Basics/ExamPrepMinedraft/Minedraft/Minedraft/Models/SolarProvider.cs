using System;
using System.Collections.Generic;
using System.Text;


public class SolarProvider : Provider
{
    public SolarProvider(string id, double energyOutput) : base(id, energyOutput)
    {
        this.Type = "Solar";
    }

    public override string ToString()
    {
        return $"{this.Type} {base.GetType().BaseType.Name} - {base.ToString()}";
    }
}

