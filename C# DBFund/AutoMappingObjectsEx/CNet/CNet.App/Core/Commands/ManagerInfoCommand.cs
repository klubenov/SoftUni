using System;
using System.Collections.Generic;
using System.Text;
using CNet.App.Core.Contracts;
using CNet.App.Core.Dtos;

namespace CNet.App.Core.Commands
{
    public class ManagerInfoCommand : ICommand
    {
        private readonly IManagerController controller;

        public ManagerInfoCommand(IManagerController controller)
        {
            this.controller = controller;
        }

        public string Execute(string[] args)
        {
            int managerId = int.Parse(args[0]);

            ManagerDto managerDto = controller.ManagerInfo(managerId);

            return managerDto.ToString();
        }
    }
}
