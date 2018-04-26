using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class ShutdownCommand : Command
{
    private IProviderController providerController;
    private IHarvesterController harvesterController;

    public ShutdownCommand(IProviderController providerController, IHarvesterController harvesterController, IList<string> arguments) : base(arguments)
    {
        this.providerController = providerController;
        this.harvesterController = harvesterController;
    }

    public override string Execute()
    {
        var sb = new StringBuilder();
        sb.AppendLine("System Shutdown");
        sb.AppendLine(string.Format(Constants.TotalEnergyProduced,
            this.providerController.TotalEnergyProduced));
        sb.Append(string.Format(Constants.TotalOreProduced, this.harvesterController.OreProduced));

        return sb.ToString();
    }
}
