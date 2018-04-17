using System;
using System.Collections.Generic;
using System.Text;


public class Car
{
    public string Name { get; set; }

    public double FuelAmount { get; set; }

    public double FuelComsumptionPerKm { get; set; }

    public double DistanceTraveled { get; set; }

    public Car(string name, double fuelAmount, double fuelComsumptionPerKm)
    {
        Name = name;
        FuelComsumptionPerKm = fuelComsumptionPerKm;
        FuelAmount = fuelAmount;
        DistanceTraveled = 0;
    }

    public void Drive(double kmDriven)
    {
        if (kmDriven*FuelComsumptionPerKm<=FuelAmount)
        {
            FuelAmount -= kmDriven * FuelComsumptionPerKm;
            DistanceTraveled += kmDriven;
        }
        else
        {
            Console.WriteLine("Insufficient fuel for the drive");
        }
    }

    public override string ToString()
    {
        return $"{Name} {FuelAmount:f2} {DistanceTraveled}";
    }
}
