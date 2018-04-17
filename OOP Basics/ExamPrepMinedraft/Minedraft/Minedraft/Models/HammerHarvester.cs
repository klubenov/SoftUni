using System;
using System.Collections.Generic;
using System.Text;


public class HammerHarvester : Harvester
{
    public HammerHarvester(string id, double oreOutput, double energyRequirement)
        : base(id, oreOutput*3, energyRequirement*2)
    {
        this.Type = "Hammer";
    }

    public override string ToString()
    {
        return $"{this.Type} {base.GetType().BaseType.Name} - {base.ToString()}";
    }
}

