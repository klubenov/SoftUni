using System;

public abstract class Harvester : IHarvester
{
    protected const int initialDurability = 1000;
    private const double defaultDurabilityLoss = 100;

    private double durability;

    protected Harvester(int id, double oreOutput, double energyRequirement)
    {
        this.ID = id;
        this.OreOutput = oreOutput;
        this.EnergyRequirement = energyRequirement;
        this.Durability = initialDurability;
    }

    public int ID { get; }

    public double OreOutput { get; protected set; }

    public double EnergyRequirement { get; protected set; }

    public virtual double Durability
    {
        get { return this.durability; }
        protected set
        {
            if (value<0)
            {
                throw new ArgumentException();
            }
            this.durability = value;
        }
    }

    public void Broke()
    {
        this.Durability -= defaultDurabilityLoss;
    }

    public double Produce()
    {
        return this.OreOutput;
    }
}