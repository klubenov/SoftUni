using System;
using System.Collections.Generic;
using System.Linq;


class P6CompanyRoster
{
    static void Main(string[] args)
    {
        int entriesCount = int.Parse(Console.ReadLine());

        var employeeDict = new Dictionary<string,List<Employee>>();

        for (int i = 0; i < entriesCount; i++)
        {
            var employeeData = Console.ReadLine().Split(' ');
            var newEmployee = new Employee(employeeData[0], decimal.Parse(employeeData[1]), employeeData[2], employeeData[3]);
            if (employeeData.Length == 5)
            {
                if (int.TryParse(employeeData[4],out int age))
                {
                    newEmployee.Age = age;
                }
                else
                {
                    newEmployee.Email = employeeData[4];
                }
            }
            else if(employeeData.Length==6)
            {
                newEmployee.Email = employeeData[4];
                newEmployee.Age = int.Parse(employeeData[5]);
            }
            if (employeeDict.ContainsKey(employeeData[3]))
            {
                employeeDict[employeeData[3]].Add(newEmployee);
            }
            else
            {
                employeeDict.Add(employeeData[3], new List<Employee>());
                employeeDict[employeeData[3]].Add(newEmployee);
            }
        }
        string maxAverageSalaryDept = "";
        decimal maxAverageSalary = 0.0M;
        foreach (var department in employeeDict)
        {
            var averageSalary = department.Value.Average(s => s.Salaray);
            if (averageSalary>=maxAverageSalary)
            {
                maxAverageSalary = averageSalary;
                maxAverageSalaryDept = department.Key;
            }
        }
        Console.WriteLine($"Highest Average Salary: {maxAverageSalaryDept}");
        foreach (var employee in employeeDict[maxAverageSalaryDept].OrderByDescending(s=>s.Salaray))
        {
            Console.WriteLine($"{employee.Name} {employee.Salaray:f2} {employee.Email} {employee.Age}");
        }
    }
}

