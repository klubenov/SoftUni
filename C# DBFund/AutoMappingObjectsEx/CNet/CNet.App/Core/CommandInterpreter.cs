namespace CNet.App.Core
{
    using System;
    using System.Linq;
    using System.Reflection;

    using Contracts;

    public class CommandInterpreter : ICommandInterpreter
    {
        private readonly IServiceProvider serviceProvider;

        public CommandInterpreter(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public string Read(string[] input)
        {
            string commandName = input[0] + "Command";

            string[] args = input.Skip(1).ToArray();

            var type = Assembly.GetCallingAssembly()
                .GetTypes().FirstOrDefault(x => x.Name == commandName);

            if (type == null)
            {
                throw new ArgumentException("Ivalid command! Please enter a valid command");
            }

            var ctor = type.GetConstructors().First();

            var ctorParams = ctor.GetParameters().Select(x => x.ParameterType).ToArray();

            var service = ctorParams.Select(serviceProvider.GetService).ToArray();

            var command = (ICommand) ctor.Invoke(service);

            var result = command.Execute(args);

            return result;
        }
    }
}
