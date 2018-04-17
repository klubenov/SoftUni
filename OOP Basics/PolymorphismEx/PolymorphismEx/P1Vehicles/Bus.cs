using System;
using System.Collections.Generic;
using System.Text;


public class Bus : Vehicle
{
    public Bus(double fuelQuantity, double fuelConsumptionInLitersPerKm, double tankCapacity) : base(fuelQuantity,
        fuelConsumptionInLitersPerKm, tankCapacity)
    {
        this.FuelConsumptionInLitersPerKm += 1.4;
    }

    public override void DriveEmpty(double distance)
    {
        if (this.FuelQuantity > distance * (this.FuelConsumptionInLitersPerKm-1.4))
        {
            this.FuelQuantity -= distance * (this.FuelConsumptionInLitersPerKm - 1.4);
        }
        else
        {
            throw new ArgumentException($"{this.GetType().Name} needs refueling");
        }
    }
}

