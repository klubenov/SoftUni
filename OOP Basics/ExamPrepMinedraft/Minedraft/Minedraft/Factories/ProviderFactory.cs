using System;
using System.Collections.Generic;
using System.Text;


public class ProviderFactory
{
    public Provider InstantiateProvider(List<string> providerData)
    {
        switch (providerData[0])
        {
            case "Solar":
                return new SolarProvider(providerData[1], double.Parse(providerData[2]));
            case "Pressure":
                return new PressureProvider(providerData[1], double.Parse(providerData[2]));
        }

        throw new ArgumentException("Invalid provider parameters!");
    }
}

