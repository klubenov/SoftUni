using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;


public class DriverFactory
{
    public Driver CreateDriver(List<string> driverData)
    {
        TyreFactory tyreFactory = new TyreFactory();
        switch (driverData[0])
        {
            case "Aggressive":
                return new AggressiveDriver(driverData[1], new Car(int.Parse(driverData[2]), double.Parse(driverData[3]), tyreFactory.CreateTyre(driverData.Skip(4).ToList())));
            case "Endurance":
                return new EnduranceDriver(driverData[1], new Car(int.Parse(driverData[2]), double.Parse(driverData[3]), tyreFactory.CreateTyre(driverData.Skip(4).ToList())));
        }

        throw new InvalidDataException("Invalid driver data!");
    }
}

