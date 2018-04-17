using System;
using System.Collections.Generic;
using System.Text;


public class Car : Vehicle
{
    public Car(double fuelQuantity, double fuelConsumptionInLitersPerKm, double tankCapacity) : base(fuelQuantity,
        fuelConsumptionInLitersPerKm, tankCapacity)
    {
        this.FuelConsumptionInLitersPerKm += 0.9;
    }

    public override void DriveEmpty(double distance)
    {
        
    }
}

