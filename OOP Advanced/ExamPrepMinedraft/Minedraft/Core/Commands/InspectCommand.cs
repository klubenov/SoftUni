using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class InspectCommand : Command
{
    public InspectCommand(ICommandInterpreter commandInterpreter, IList<string> arguments) : base(commandInterpreter, arguments)
    {
    }

    public override string Execute()
    {
        var id = int.Parse(Arguments[0]);

        var providerControllerAsClass = this.commandInterpreter.ProviderController as ProviderController;
        var harvesterControllerAsClass = this.commandInterpreter.HarvesterController as HarvesterController;

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

