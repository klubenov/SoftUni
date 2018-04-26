using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class InspectCommand : Command
{
    private IProviderController providerController;
    private IHarvesterController harvesterController;

    public InspectCommand(IProviderController providerController, IHarvesterController harvesterController, IList<string> arguments) : base(arguments)
    {
        this.providerController = providerController;
        this.harvesterController = harvesterController;
    }

    public override string Execute()
    {
        var id = int.Parse(Arguments[0]);

        var providerControllerAsClass = this.providerController as ProviderController;
        var harvesterControllerAsClass = this.harvesterController as HarvesterController;

        foreach (var provider in providerControllerAsClass.Entities)
        {
            if (provider.ID == id)
            {
                return string.Format(Constants.InspectSuccessful, provider.GetType().Name,Environment.NewLine, provider.Durability);
            }
        }
        foreach (var harvester in harvesterControllerAsClass.Entities)
        {
            if (harvester.ID == id)
            {
                return string.Format(Constants.InspectSuccessful, harvester.GetType().Name,Environment.NewLine, harvester.Durability);
            }
        }

        return string.Format(Constants.EntityNotFound, id);
    }
}

