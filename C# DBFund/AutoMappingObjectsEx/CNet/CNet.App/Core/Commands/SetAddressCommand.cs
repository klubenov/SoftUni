namespace CNet.App.Core.Commands
{
    using Contracts;

    public class SetAddressCommand : ICommand
    {
        private readonly IEmployeeController controller;

        public SetAddressCommand(IEmployeeController controller)
        {
            this.controller = controller;
        }

        public string Execute(string[] args)
        {
            int employeeId = int.Parse(args[0]);
            string newAddress = args[1];

            this.controller.SetAddress(employeeId,newAddress);

            return $"The address of employee with employeeId set to {newAddress}";
        }
    }
}
