using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace CNet.App.Core.Controllers
{
    using Contracts;
    using Dtos;
    using Data;
    using Models;

    public class EmployeeController : IEmployeeController
    {
        private readonly CNetContext context;
        private readonly IMapper mapper;

        public EmployeeController(CNetContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public void AddEmployee(EmployeeDto employeeDto)
        {
            var employee = mapper.Map<Employee>(employeeDto);

            this.context.Employees.Add(employee);

            this.context.SaveChanges();
        }

        public void SetBirthday(int employeeId, DateTime date)
        {
            var employee = context.Employees.Find(employeeId);

            if (employee == null)
            {
                throw new ArgumentException("Invalid Id");
            }

            employee.Birthday = date;

            context.SaveChanges();
        }

        public void SetAddress(int employeeId, string address)
        {
            var employee = context.Employees.Find(employeeId);

            if (employee == null)
            {
                throw new ArgumentException("Invalid Id");
            }

            employee.Address = address;

            context.SaveChanges();
        }

        public EmployeeDto EmployeeInfo(int employeeId)
        {
            var employee = context.Employees.Find(employeeId);

            var employeeDto = mapper.Map<EmployeeDto>(employee);


            if (employee == null)
            {
                throw new ArgumentException("Invalid Id");
            }

            return employeeDto;
        }

        public EmployeePersonalInfoDto EmployeePersonalInfo(int employeeId)
        {
            var employee = context.Employees.Find(employeeId);

            var employeeDto = mapper.Map<EmployeePersonalInfoDto>(employee);

            if (employee == null)
            {
                throw new ArgumentException("Invalid Id");
            }

            return employeeDto;
        }

        public ICollection<EmployeeByAgeDto> ListEmployeesOlderThan(int age)
        {
            var employees = context.Employees.Include(x => x.Manager)
                .Where(x => x.Birthday != null & (DateTime.Now - x.Birthday.GetValueOrDefault()).TotalDays > age*365)
                .Select(x => mapper.Map<EmployeeByAgeDto>(x))
                .OrderByDescending(x => x.Salary)
                .ToArray();

            return employees;
        }
    }
}
