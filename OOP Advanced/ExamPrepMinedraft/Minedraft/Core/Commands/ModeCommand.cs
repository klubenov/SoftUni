using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class ModeCommand : Command
{
    public ModeCommand(ICommandInterpreter commandInterpreter,IList<string> arguments) : base(commandInterpreter,arguments)
    {
    }

    public override string Execute()
    {
        return this.commandInterpreter.HarvesterController.ChangeMode(Arguments[0]);
    }
}

