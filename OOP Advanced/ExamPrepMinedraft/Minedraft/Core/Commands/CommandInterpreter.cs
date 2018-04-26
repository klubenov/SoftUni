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
        var commandConstructor = commandType.GetConstructors().First();

        ParameterInfo[] ctorParameters = commandConstructor.GetParameters();

        object[] parameters = new object[ctorParameters.Length];

        for (int i = 0; i < parameters.Length; i++)
        {
            Type parameterType = ctorParameters[i].ParameterType;

            if (parameterType == typeof(IList<string>))
            {
                parameters[i] = args.Skip(1).ToList();
            }
            else
            {
                PropertyInfo paramInfo =
                    this.GetType().GetProperties().FirstOrDefault(p => p.PropertyType == parameterType);
                parameters[i] = paramInfo.GetValue(this);
            }
        }

        var command = commandConstructor.Invoke(parameters);
        var result = ((ICommand) command).Execute();

        return result;
    }
}

