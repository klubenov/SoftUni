using System;
using System.Collections.Generic;
using System.Text;


public class Car
{
    public int Hp { get; }

    private double fuelAmount;

    public double FuelAmount
    {
        get { return this.fuelAmount; }
        private set
        {
            if (value < 0)
            {
                throw new ArgumentException("Out of fuel");
            }

            this.fuelAmount = Math.Min(160,value);
        }
    }

    public Tyre Tyre { get; private set; }

    public Car(int hp, double fuelAmount, Tyre tyre)
    {
        this.Hp = hp;
        this.FuelAmount = fuelAmount;
        this.Tyre = tyre;
    }

    public void SpendFuelForOneLap(int trackLength, double fuelConsuptionPerKm)
    {
        this.FuelAmount -= trackLength * fuelConsuptionPerKm;
    }

    public void Refuel(double fuelAmount)
    {
        this.fuelAmount += fuelAmount;
    }

    public void ChangeTyre(Tyre tyre)
    {
        this.Tyre = tyre;
    }
}

