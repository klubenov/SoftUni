namespace CNet.App.Core.Commands
{
    using Contracts;
    using Dtos;

    public class AddEmployeeCommand : ICommand
    {
        private readonly IEmployeeController controller;

        public AddEmployeeCommand(IEmployeeController controller)
        {
            this.controller = controller;
        }


        public string Execute(string[] args)
        {
            string firstName = args[0];
            string lastName = args[1];
            decimal salary = decimal.Parse(args[2]);

            var employeeDto = new EmployeeDto
            {
                FirstName = firstName,
                LastName = lastName,
                Salary = salary
            };

            this.controller.AddEmployee(employeeDto);

            return $"Emplyee {firstName} {lastName} was added successfully";
        }
    }
}
