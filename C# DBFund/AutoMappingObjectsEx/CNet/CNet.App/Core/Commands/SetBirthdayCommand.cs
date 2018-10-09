namespace CNet.App.Core.Commands
{
    using System;
    using System.Globalization;
    using Contracts;

    public class SetBirthdayCommand : ICommand
    {
        private readonly IEmployeeController controller;

        public SetBirthdayCommand(IEmployeeController controller)
        {
            this.controller = controller;
        }

        public string Execute(string[] args)
        {
            int employeeId = int.Parse(args[0]);
            DateTime birthDate = DateTime.ParseExact(args[1], "dd-MM-yyyy", CultureInfo.InvariantCulture);

            this.controller.SetBirthday(employeeId, birthDate);

            return $"The birth date of employee with employeeId {employeeId} set to {args[1]}";
        }
    }
}
