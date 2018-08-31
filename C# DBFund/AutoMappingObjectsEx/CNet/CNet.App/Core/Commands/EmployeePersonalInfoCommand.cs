namespace CNet.App.Core.Commands
{
    using Contracts;
    using Dtos;

    public class EmployeePersonalInfoCommand : ICommand
    {
        private readonly IEmployeeController controller;

        public EmployeePersonalInfoCommand(IEmployeeController controller)
        {
            this.controller = controller;
        }


        public string Execute(string[] args)
        {
            int employeeId = int.Parse(args[0]);

            EmployeePersonalInfoDto employee = this.controller.EmployeePersonalInfo(employeeId);

            return employee.ToString();
        }
    }
}
