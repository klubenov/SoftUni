using System;
using System.Collections.Generic;
using System.Text;

class Car
{
    public string Model { get; set; }
    public int EngineSpeed { get; set; }
    public int EnginePower { get; set; }
    public int CargoWeight { get; set; }
    public string CargoType { get; set; }
    public KeyValuePair<double,int>[] Tires { get; set; }

    //private string model;
    //private int engineSpeed;
    //private int enginePower;
    //private int cargoWeight;
    //private string cargoType;
    //private KeyValuePair<double, int>[] tires;


    public Car(string model, int engineSpeed, int enginePower, int cargoWeight, string cargoType, double tire1Pressure, int tire1Age, double tire2Pressure, int tire2Age, double tire3Pressure, int tire3age, double tire4Pressure, int tire4age)
    {
        Model = model;
        EngineSpeed = engineSpeed;
        EnginePower = enginePower;
        CargoWeight = cargoWeight;
        CargoType = cargoType;
        Tires = new KeyValuePair<double, int>[] { KeyValuePair.Create(tire1Pressure, tire1Age), KeyValuePair.Create(tire2Pressure, tire2Age), KeyValuePair.Create(tire3Pressure, tire3age), KeyValuePair.Create(tire4Pressure, tire4age) };
    }
}