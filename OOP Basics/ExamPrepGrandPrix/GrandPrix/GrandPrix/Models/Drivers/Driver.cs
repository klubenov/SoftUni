using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public abstract class Driver
{
    public string Name { get; }

    public double TotalTime { get; private set; }

    public Car Car { get; }

    public double FuelConsumptionPerKm { get; }

    public virtual double Speed => (this.Car.Hp + this.Car.Tyre.Degradation) / this.Car.FuelAmount;

    public bool IsDnf { get; private set; }

    public string DnfReason { get; private set; }

    private string Status => IsDnf ? this.DnfReason : this.TotalTime.ToString("f3");


    protected Driver(string name, Car car, double fuelConsumptionPerKm)
    {
        this.Name = name;
        this.Car = car;
        this.FuelConsumptionPerKm = fuelConsumptionPerKm;
        this.TotalTime = 0d;
        this.IsDnf = false;
        this.DnfReason = null;
    }

    public void CompleteLap(int trackLength)
    {
        this.TotalTime += 60 / (trackLength / this.Speed);
        try
        {
            this.Car.SpendFuelForOneLap(trackLength,this.FuelConsumptionPerKm);
            this.Car.Tyre.Degrade();
        }
        catch (ArgumentException exception)
        {
            this.DnfDriver(exception.Message);
        }
    }

    public void Box(List<string> boxData)
    {
        this.TotalTime += 20;
        if (boxData.Count == 1)
        {
            this.Car.Refuel(double.Parse(boxData[0]));
        }
        else
        {
            var tyreFactory = new TyreFactory();
            var newTyre = tyreFactory.CreateTyre(boxData);
            this.Car.ChangeTyre(newTyre);
        }
    }

    public override string ToString()
    {
        return $"{this.Name} {this.Status}";
    }

    public void DnfDriver(string dnfReason)
    {
        this.IsDnf = true;
        this.DnfReason = dnfReason;
    }

    public void Overtake()
    {
        this.TotalTime -= 2;
    }

    public void GetOvertaken()
    {
        this.TotalTime += 2;
    }
}

