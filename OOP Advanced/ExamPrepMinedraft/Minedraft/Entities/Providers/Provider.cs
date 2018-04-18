using System;

public abstract class Provider : IProvider
{
    private const double initialDurability = 1000;
    private const double defaultDurabilityLoss = 100;

    protected Provider(int id, double energyOutput)
    {
        this.ID = id;
        this.EnergyOutput = energyOutput;
        this.Durability = initialDurability;
    }

    public int ID { get; }

    public double Durability { get; protected set; }

    public double EnergyOutput { get; protected set; }

    public void Broke()
    {
        this.Durability -= defaultDurabilityLoss;

        if (this.Durability<0)
        {
            throw new Exception();
        }
    }

    public virtual double Produce()
    {
        return this.EnergyOutput;
    }

    public void Repair(double val)
    {
        this.Durability += val;
    }
}