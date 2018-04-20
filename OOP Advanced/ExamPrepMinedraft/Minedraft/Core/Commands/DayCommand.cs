using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class DayCommand : Command
{
    private IProviderController providerController;
    private IHarvesterController harvesterController;

    public DayCommand(IProviderController providerController, IHarvesterController harvesterController, IList<string> arguments) : base(arguments)
    {
        this.providerController = providerController;
        this.harvesterController = harvesterController;
    }

    public override string Execute()
    {
        var productionStringBuilder = new StringBuilder();

        productionStringBuilder.AppendLine(this.providerController.Produce())
            .Append(this.harvesterController.Produce());

        return productionStringBuilder.ToString();
    }
}

