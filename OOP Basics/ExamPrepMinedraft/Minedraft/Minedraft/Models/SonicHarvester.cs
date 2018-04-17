using System;
using System.Collections.Generic;
using System.Text;


public class SonicHarvester : Harvester
{
    public SonicHarvester(string id, double oreOutput, double energyRequirement, int sonicFactor) 
        : base(id, oreOutput,energyRequirement/sonicFactor)
    {
        this.Type = "Sonic";
    }

    public override string ToString()
    {
        return $"{this.Type} {base.GetType().BaseType.Name} - {base.ToString()}";
    }
}

