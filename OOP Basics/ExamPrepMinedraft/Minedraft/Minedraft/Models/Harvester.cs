using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;


public abstract class Harvester : Unit
{
    private double oreOutput;

    public double OreOutput
    {
        get { return this.oreOutput; }
        private set
        {
            if (value<0)
            {
                throw new ArgumentException("Harvester is not registered, because of it's OreOutput");
            }
            this.oreOutput = value;
        }
    }

    private double energyRequirement;

    public double EnergyRequirement
    {
        get { return this.energyRequirement; }
        private set
        {
            if (value<0 || value>20000)
            {
                throw new ArgumentException("Harvester is not registered, because of it's EnergyRequirement");
            }
            this.energyRequirement = value;
        }
    }

    protected Harvester(string id, double oreOutput, double energyRequirement):base(id)
    {
        this.OreOutput = oreOutput;
        this.EnergyRequirement = energyRequirement;
    }

    public override string ToString()
    {
        return $"{this.Id}\r\nOre Output: {this.oreOutput}\r\nEnergy Requirement: {this.EnergyRequirement}";
    }
}

