using System;
using System.Collections.Generic;
using System.Text;
using _03BarracksFactory.Contracts;

namespace P03_BarraksWars.Core.Commands
{
    public class CommandInterpreter : ICommandInterpreter
    {
        private IRepository repository;
        private IUnitFactory unitFactory;

        public CommandInterpreter(IRepository repository, IUnitFactory unitFactory)
        {
            this.repository = repository;
            this.unitFactory = unitFactory;
        }

        public IExecutable InterpretCommand(string[] data, string commandName)
        {
            var commandArr = commandName.ToCharArray();
            commandArr[0] = char.ToUpper(commandArr[0]);
            commandName = string.Join("", commandArr);

            var typeFullName = $"P03_BarraksWars.Core.Commands.{commandName}";
            var commandType = Type.GetType(typeFullName);
            IExecutable command =
                (IExecutable)Activator.CreateInstance(commandType, new object[] { data, repository, unitFactory });

            return command;
        }
    }
}
