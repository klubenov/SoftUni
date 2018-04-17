using System;
using System.Collections.Generic;
using System.Text;


public class Truck : Vehicle
{
    public Truck(double fuelQuantity, double fuelConsumptionInLitersPerKm, double tankCapacity) : base(fuelQuantity,
        fuelConsumptionInLitersPerKm, tankCapacity)
    {
        this.FuelConsumptionInLitersPerKm += 1.6;
    }

    public override void Refuel(double litersAmount)
    {
        if (litersAmount <= 0)
        {
            throw new ArgumentException("Fuel must be a positive number");
        }
        if (FuelQuantity + litersAmount > TankCapacity)
        {
            throw new ArgumentException($"Cannot fit {litersAmount} fuel in the tank");
        }
        this.FuelQuantity += litersAmount*0.95;
    }

    public override void DriveEmpty(double distance)
    {

    }
}

