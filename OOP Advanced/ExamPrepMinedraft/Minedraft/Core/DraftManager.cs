using System;
using System.Collections.Generic;
using System.Text;

public class DraftManager
{

    private IHarvesterController harvesterController;
    private IProviderController providerController;


    public DraftManager(IProviderController providerController, IHarvesterController harvesterController)
    {
        this.providerController = providerController;
        this.harvesterController = harvesterController;
    }

    public string RegisterHarvester(List<string> arguments)
    {
        return this.harvesterController.Register(arguments);
    }

    public string RegisterProvider(List<string> arguments)
    {
        return this.providerController.Register(arguments);
    }

    public string Day()
    {
        var productionStringBuilder = new StringBuilder();

        productionStringBuilder.AppendLine(this.providerController.Produce())
            .Append(this.harvesterController.Produce());

        return productionStringBuilder.ToString();
    }

    public string Mode(List<string> arguments)
    {
        return this.harvesterController.ChangeMode(arguments[0]);
    }

    public string Check(List<string> arguments)
    {
        var id = int.Parse(arguments[0]);

        var providerControllerAsClass = providerController as ProviderController;
        var harvesterControllerAsClass = harvesterController as HarvesterController;

        foreach(var provider in providerControllerAsClass.Entities)
        {
            if(provider.ID == id)
            {
                return string.Format(Constants.InspectSuccessful, provider.GetType().Name, provider.Durability);
            }
        }
        foreach(var harvester in harvesterControllerAsClass.Entities)
        {
            if (harvester.ID == id)
            {
                return string.Format(Constants.InspectSuccessful, harvester.GetType().Name, harvester.Durability);
            }
        }

        return string.Format(Constants.EntityNotFound, id);
    }

    public string ShutDown()
    {
        var sb = new StringBuilder();
        sb.AppendLine("System Shutdown");
        sb.AppendLine($"Total Energy Stored: {this.providerController.TotalEnergyProduced}");
        sb.Append($"Total Mined Plumbus Ore: {this.harvesterController.OreProduced}");

        return sb.ToString();
    }

}
