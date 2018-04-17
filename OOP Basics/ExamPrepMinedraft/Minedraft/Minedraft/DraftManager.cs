using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class DraftManager
{
    private List<Unit> Units { get; set; }

    private List<Provider> Providers { get; set; }

    private List<Harvester> Harvesters { get; set; }

    private string HarvesterMode { get; set; }

    private double TotalEnergyStored { get; set; }

    private double TotalMinedStored { get; set; }

    public DraftManager()
    {
        this.HarvesterMode = "Full";
        this.Units = new List<Unit>();
        this.Harvesters = new List<Harvester>();
        this.Providers = new List<Provider>();
    }

    public string RegisterHarvester(List<string> arguments)
    {
        try
        {
            var harvesterFactory = new HarvesterFactory();
            var newHarvester = harvesterFactory.InstantiateHarvester(arguments);
            this.Units.Add(newHarvester);
            this.Harvesters.Add(newHarvester);
            return $"Successfully registered {arguments[0]} Harvester - {arguments[1]}";
        }
        catch (ArgumentException exception)
        {
            return exception.Message;
        }
    }

    public string RegisterProvider(List<string> arguments)
    {
        try
        {
            var providerFactory = new ProviderFactory();
            var newProvider = providerFactory.InstantiateProvider(arguments);
            this.Units.Add(newProvider);
            this.Providers.Add(newProvider);
            return $"Successfully registered {arguments[0]} Provider - {arguments[1]}";
        }
        catch (ArgumentException exception)
        {
            return exception.Message;
        }
    }

    public string Day()
    {
        var energyProvidedForTheDay = Providers.Sum(p => p.EnergyOutput);
        this.TotalEnergyStored += energyProvidedForTheDay;
        double mineableForTheDay = 0;
        double energyConsumedForTheDay = 0;
        switch (this.HarvesterMode)
        {
            case "Full":
                mineableForTheDay = Harvesters.Sum(h => h.OreOutput);
                energyConsumedForTheDay = Harvesters.Sum(h => h.EnergyRequirement);
                break;
            case "Half":
                mineableForTheDay = 0.5*Harvesters.Sum(h => h.OreOutput);
                energyConsumedForTheDay = 0.6*Harvesters.Sum(h => h.EnergyRequirement);
                break;
        }
        if (TotalEnergyStored>=energyConsumedForTheDay)
        {
            this.TotalMinedStored += mineableForTheDay;
            this.TotalEnergyStored -= energyConsumedForTheDay;
        }
        else
        {
            mineableForTheDay = 0;
        }

        return
            $"A day has passed.\r\nEnergy Provided: {energyProvidedForTheDay}\r\nPlumbus Ore Mined: {mineableForTheDay}";
    }

    public string Mode(List<string> arguments)
    {
        this.HarvesterMode = $"{arguments[0]}";
        return $"Successfully changed working mode to {arguments[0]}";
    }

    public string Check(List<string> arguments)
    {
        var operatorById = Units.Find(o => o.Id == arguments[0]);
        if (operatorById==null)
        {
            return $"No element found with id - {arguments[0]}";
        }
        return operatorById.ToString();
    }

    public string ShutDown()
    {
        return
            $"System Shutdown\r\nTotal Energy Stored: {this.TotalEnergyStored}\r\nTotal Mined Plumbus Ore: {this.TotalMinedStored}";
    }
}

