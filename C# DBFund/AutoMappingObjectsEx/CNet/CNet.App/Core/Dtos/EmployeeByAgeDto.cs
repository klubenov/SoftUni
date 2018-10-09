using System;
using System.Collections.Generic;
using System.Text;

namespace CNet.App.Core.Dtos
{
    public class EmployeeByAgeDto
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public decimal Salary { get; set; }

        public ManagerDto ManagerDto { get; set; }

        public override string ToString()
        {
            string managerText;
            if (ManagerDto == null)
            {
                managerText = "[no manager]";
            }
            else
            {
                managerText = ManagerDto.LastName;
            }
            return $"{FirstName} {LastName} - ${Salary:f2} - Manager: {managerText}";
        }
    }
}
