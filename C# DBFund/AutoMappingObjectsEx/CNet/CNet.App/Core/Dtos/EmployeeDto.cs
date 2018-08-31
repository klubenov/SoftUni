namespace CNet.App.Core.Dtos
{
    public class EmployeeDto
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public decimal Salary { get; set; }

        public override string ToString()
        {
            return $"ID: {Id} - {FirstName} {LastName} - ${Salary:f2}";
        }
    }
}
