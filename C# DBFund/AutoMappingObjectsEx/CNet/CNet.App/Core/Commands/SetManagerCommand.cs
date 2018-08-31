using System;
using System.Collections.Generic;
using System.Text;
using CNet.App.Core.Contracts;

namespace CNet.App.Core.Commands
{
    public class SetManagerCommand : ICommand
    {
        private readonly IManagerController controller;

        public SetManagerCommand(IManagerController controller)
        {
            this.controller = controller;
        }

        public string Execute(string[] args)
        {
            var employeeId = int.Parse(args[0]);
            var managerId = int.Parse(args[1]);

            controller.SetManager(employeeId,managerId);

            return "Manager set successfully";
        }
    }
}
