using System;
using System.Text;

namespace CNet.App.Core.Dtos
{
    using System.Collections.Generic;

    public class ManagerDto
    {
        public ManagerDto()
        {
            this.EmployeeDtos = new HashSet<EmployeeDto>();
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public ICollection<EmployeeDto> EmployeeDtos { get; set; }

        public override string ToString()
        {
            var employeesCount = this.EmployeeDtos.Count;
            var employeesSb = new StringBuilder();

            foreach (var employeeDto in EmployeeDtos)
            {
                employeesSb.AppendLine(
                    $"    - {employeeDto.FirstName} {employeeDto.LastName} - ${employeeDto.Salary:f2}");
            }

            return
                $"{this.FirstName} {this.LastName} | Employees: {employeesCount}{Environment.NewLine}{employeesSb.ToString().TrimEnd()}";
        }
    }
}
