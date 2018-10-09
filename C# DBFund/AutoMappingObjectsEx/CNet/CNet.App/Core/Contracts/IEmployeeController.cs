namespace CNet.App.Core.Contracts
{
    using System;
    using System.Collections.Generic;

    using Dtos;

    public interface IEmployeeController
    {
        void AddEmployee(EmployeeDto employeeDto);

        void SetBirthday(int employeeId, DateTime date);

        void SetAddress(int employeeId, string address);

        EmployeeDto EmployeeInfo(int employeeId);

        EmployeePersonalInfoDto EmployeePersonalInfo(int employeeId);

        ICollection<EmployeeByAgeDto> ListEmployeesOlderThan(int age);
    }
}
