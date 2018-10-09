namespace CNet.App.Core.Dtos
{
    using System;
    using System.Globalization;


    public class EmployeePersonalInfoDto
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public decimal Salary { get; set; }

        public DateTime? Birthday { get; set; }

        public string Address { get; set; }

        public override string ToString()
        {
            return $"ID: {Id} - {FirstName} {LastName} - ${Salary}{Environment.NewLine}" +
                   $"Birthday: {Birthday.GetValueOrDefault().ToString("dd-MM-yyyy", CultureInfo.InvariantCulture)}{Environment.NewLine}" +
                   $"Address: {Address}";
        }
    }
}
