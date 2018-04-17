using System;
using System.Collections.Generic;
using System.Text;


public abstract class Vehicle
{
    protected double FuelQuantity { get; set; }

    protected double FuelConsumptionInLitersPerKm { get; set; }

    protected double TankCapacity { get; }

    protected Vehicle(double fuelQuantity, double fuelConsumptionInLitersPerKm, double tankCapacity)
    {
        if (fuelQuantity<=tankCapacity)
        {
            this.FuelQuantity = fuelQuantity;
        }
        this.FuelConsumptionInLitersPerKm = fuelConsumptionInLitersPerKm;
        this.TankCapacity = tankCapacity;
    }

    public void Drive(double distance)
    {
        if (this.FuelQuantity > distance * FuelConsumptionInLitersPerKm)
        {
            this.FuelQuantity -= distance * FuelConsumptionInLitersPerKm;
        }
        else
        {
            throw new ArgumentException($"{this.GetType().Name} needs refueling");
        }
    }

    public virtual void Refuel(double litersAmount)
    {
        if (litersAmount<=0)
        {
            throw new ArgumentException("Fuel must be a positive number");
        }
        if (FuelQuantity+litersAmount>TankCapacity)
        {
            throw new ArgumentException($"Cannot fit {litersAmount} fuel in the tank");
        }
        this.FuelQuantity += litersAmount;
    }

    public abstract void DriveEmpty(double distance);


    public double GetFuelAmount()
    {
        return this.FuelQuantity;
    }
}

