using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class ShutdownCommand : Command
{
    public ShutdownCommand(ICommandInterpreter commandInterpreter, IList<string> arguments) : base(commandInterpreter, arguments)
    {
    }

    public override string Execute()
    {
        var sb = new StringBuilder();
        sb.AppendLine("System Shutdown");
        sb.AppendLine(string.Format(Constants.TotalEnergyProduced,
            this.commandInterpreter.ProviderController.TotalEnergyProduced));
        sb.Append(string.Format(Constants.TotalOreProduced,this.commandInterpreter.HarvesterController.OreProduced));

        return sb.ToString();
    }
}
