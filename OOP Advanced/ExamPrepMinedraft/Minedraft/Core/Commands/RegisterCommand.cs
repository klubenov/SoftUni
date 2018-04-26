using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class RegisterCommand : Command
{
    private IProviderController providerController;
    private IHarvesterController harvesterController;

    public RegisterCommand(IProviderController providerController, IHarvesterController harvesterController, IList<string> arguments) : base(arguments)
    {
        this.providerController = providerController;
        this.harvesterController = harvesterController;
    }

    public override string Execute()
    {
        if (Arguments[0] == "Provider")
        {
            return this.providerController.Register(Arguments.Skip(1).ToList());
        }
        else
        {
            return this.harvesterController.Register(Arguments.Skip(1).ToList());
        }
    }
}
