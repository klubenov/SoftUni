using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class RepairCommand : Command
{
    public RepairCommand(ICommandInterpreter commandInterpreter, IList<string> arguments) : base(commandInterpreter, arguments)
    {
    }

    public override string Execute()
    {
        return this.commandInterpreter.ProviderController.Repair(double.Parse(Arguments[0]));
    }
}

