namespace CNet.App.Core.Commands
{
    using Contracts;
    using Dtos;

    public class EmployeeInfoCommand : ICommand
    {
        private readonly IEmployeeController controller;

        public EmployeeInfoCommand(IEmployeeController controller)
        {
            this.controller = controller;
        }

        public string Execute(string[] args)
        {
            int employeeId = int.Parse(args[0]);

            EmployeeDto employee = controller.EmployeeInfo(employeeId);

            return employee.ToString();
        }
    }
}
