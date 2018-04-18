using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class RegisterCommand : Command
{
    public RegisterCommand(ICommandInterpreter commandInterpreter, IList<string> arguments) : base(commandInterpreter, arguments)
    {
    }

    public override string Execute()
    {
        if (Arguments[0] == "Provider")
        {
            return this.commandInterpreter.ProviderController.Register(Arguments.Skip(1).ToList());
        }
        else
        {
            return this.commandInterpreter.HarvesterController.Register(Arguments.Skip(1).ToList());
        }
    }
}
