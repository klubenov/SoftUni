using System;
using System.Collections.Generic;
using System.Text;


public class Car
{
    public string Model { get; set; }

    public Engine Engine { get; set; }

    public object Weight { get; set; }

    public string Color { get; set; }

    public Car(string model, Engine engine)
    {
        Model = model;
        Engine = engine;
        Weight = "n/a";
        Color = "n/a";
    }

    public Car(string model, Engine engine, object weight) : this(model, engine)
    {
        Weight = weight;
    }

    public Car(string model, Engine engine, string color) : this(model, engine)
    {
        Color = color;
    }

    public Car(string model, Engine engine, object weight, string color) : this(model, engine)
    {
        Weight = weight;
        Color = color;
    }

    public override string ToString()
    {
        return $"{Model}:\r\n  {this.Engine}\r\n  Weight: {Weight}\r\n  Color: {Color}";
    }
}

