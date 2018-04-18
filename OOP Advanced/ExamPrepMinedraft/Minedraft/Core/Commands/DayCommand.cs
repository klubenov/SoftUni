using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class DayCommand : Command
{
    public DayCommand(ICommandInterpreter commandInterpreter, IList<string> arguments) : base(commandInterpreter, arguments)
    {
    }

    public override string Execute()
    {
        var productionStringBuilder = new StringBuilder();

        productionStringBuilder.AppendLine(this.commandInterpreter.ProviderController.Produce())
            .Append(this.commandInterpreter.HarvesterController.Produce());

        return productionStringBuilder.ToString();
    }
}

