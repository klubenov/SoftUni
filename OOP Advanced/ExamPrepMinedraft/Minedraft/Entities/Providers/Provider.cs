using System;

public abstract class Provider : IProvider
{
    private const double initialDurability = 1000;
    private const double defaultDurabilityLoss = 100;

    private double durability;

    protected Provider(int id, double energyOutput)
    {
        this.ID = id;
        this.EnergyOutput = energyOutput;
        this.Durability = initialDurability;
    }

    public int ID { get; }

    public double Durability
    {
        get => this.durability;
        protected set
        {
            if (value<0)
            {
                throw new ArgumentException();
            }
            this.durability = value;
        } 
    }

    public double EnergyOutput { get; protected set; }

    public void Broke()
    {
        this.Durability -= defaultDurabilityLoss;
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