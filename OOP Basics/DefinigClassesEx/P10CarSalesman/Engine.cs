using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;


public class Engine
{
    public string Model { get; set; }

    public int Power { get; set; }

    public object Displacement { get; set; }

    public string Efficiency { get; set; }

    public Engine(string model, int power)
    {
        Model = model;
        Power = power;
        Displacement = "n/a";
        Efficiency = "n/a";
    }

    public Engine(string model, int power, object displacement) :this(model, power)
    {
        Displacement = displacement;
    }

    public Engine(string model, int power, string efficiency):this(model, power)
    {
        Efficiency = efficiency;
    }

    public Engine(string model, int power, object displacement,string efficiency):this(model, power)
    {
        Displacement = displacement;
        Efficiency = efficiency;
    }

    public override string ToString()
    {
        return $"{Model}: \r\n    Power: {Power}\r\n    Displacement: {Displacement}\r\n    Efficiency: {Efficiency}";
    }
}

