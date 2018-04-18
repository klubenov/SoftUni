using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public abstract class Command : ICommand
{
    protected ICommandInterpreter commandInterpreter;

    protected Command(ICommandInterpreter commandInterpreter,IList<string> arguments)
    {
        this.Arguments = arguments;
        this.commandInterpreter = commandInterpreter;
    }


    public IList<string> Arguments { get; }

    public abstract string Execute();

}
