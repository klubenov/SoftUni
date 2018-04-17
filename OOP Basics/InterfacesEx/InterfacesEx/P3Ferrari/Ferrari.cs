using System;
using System.Collections.Generic;
using System.Text;


public class Ferrari : ICar
{
    public string DriverName { get; private set; }

    public string Model { get; private set; }

    public Ferrari(string driverName)
    {
        DriverName = driverName;
        Model = "488-Spider";
    }

    public string ApplyBrakes()
    {
        return "Brakes!";
    }

    public string PushGasPedal()
    {
        return "Zadu6avam sA!";
    }

    public override string ToString()
    {
        return $"{Model}/{ApplyBrakes()}/{PushGasPedal()}/{DriverName}";
    }
}

