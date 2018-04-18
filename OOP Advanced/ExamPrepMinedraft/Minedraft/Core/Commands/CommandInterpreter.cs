using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


public class CommandInterpreter : ICommandInterpreter
{
    public CommandInterpreter(IProviderController providerController, IHarvesterController harvesterController)
    {
        this.ProviderController = providerController;
        this.HarvesterController = harvesterController;
    }

    public IHarvesterController HarvesterController { get; }

    public IProviderController ProviderController { get; }

    public string ProcessCommand(IList<string> args)
    {
        Assembly assembly = Assembly.GetExecutingAssembly();
        Type commandType = assembly.GetType(args[0] + "Command");
        var commandConstructor = commandType.GetConstructors();
        object[] ctorParameters = new object[] {this, args.Skip(1).ToList()};
        var command = commandConstructor[0].Invoke(ctorParameters);
        var commandExecuteMethod = commandType.GetMethod("Execute");
        var result = commandExecuteMethod.Invoke(command,new object[]{});

        return result.ToString();
    }
}

