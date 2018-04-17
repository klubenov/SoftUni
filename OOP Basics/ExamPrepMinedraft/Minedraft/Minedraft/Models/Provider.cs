using System;
using System.Collections.Generic;
using System.Text;


public abstract class Provider : Unit
{

    private double energyOutput;

    public double EnergyOutput
    {
        get { return this.energyOutput; }
        private set
        {
            if (value<0 || value>10000)
            {
                throw new ArgumentException("Provider is not registered, because of it's EnergyOutput");
            }

            this.energyOutput = value;
        }
    }

    protected Provider(string id, double energyOutput):base(id)
    {
        this.EnergyOutput = energyOutput;
    }

    public override string ToString()
    {
        return $"{this.Id}\r\nEnergy Output: {this.energyOutput}";
    }
}

