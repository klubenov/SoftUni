using System;
using System.Collections.Generic;
using System.Text;
using CNet.App.Core.Contracts;
using CNet.App.Core.Dtos;

namespace CNet.App.Core.Commands
{
    public class ListEmployeesOlderThanCommand : ICommand
    {
        private readonly IEmployeeController controller;

        public ListEmployeesOlderThanCommand(IEmployeeController controller)
        {
            this.controller = controller;
        }

        public string Execute(string[] args)
        {
            int age = int.Parse(args[0]);

            EmployeeByAgeDto[] employees = (EmployeeByAgeDto[])controller.ListEmployeesOlderThan(age);

            var employeeSb = new StringBuilder();

            foreach (var employeeByAgeDto in employees)
            {
                employeeSb.AppendLine(employeeByAgeDto.ToString().TrimEnd());
            }

            return employeeSb.ToString().TrimEnd();
        }
    }
}
