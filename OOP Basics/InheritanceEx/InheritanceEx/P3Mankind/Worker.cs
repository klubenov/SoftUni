using System;
using System.Collections.Generic;
using System.Text;


class Worker : Human
{
    private decimal weekSalary;

    public decimal WeekSalary
    {
        get { return this.weekSalary; }
        set
        {
            if (value<10)
            {
                throw new ArgumentException("Expected value mismatch! Argument: weekSalary");
            }
            this.weekSalary = value;
        }
    }

    private decimal workHoursPerDay;

    public decimal WorkHoursPerDay
    {
        get { return this.workHoursPerDay; }
        set
        {
            if (value < 1 || value > 12)
            {
                throw new ArgumentException("Expected value mismatch! Argument: workHoursPerDay");
            }
            this.workHoursPerDay = value;
        }
    }

    private decimal salaryPerWorkHour;

    public decimal SalaryPerWorkHour { get; }

    public Worker(string firstName, string lastName, decimal weekSalary, decimal workHoursPerDay):base(firstName,lastName)
    {
        WeekSalary = weekSalary;
        WorkHoursPerDay = workHoursPerDay;
        SalaryPerWorkHour = weekSalary / (workHoursPerDay * 5M);
    }

    public override string ToString()
    {
        return
            $"{base.ToString()}\r\nWeek Salary: {WeekSalary:f2}\r\nHours per day: {WorkHoursPerDay:f2}\r\nSalary per hour: {SalaryPerWorkHour:f2}";
    }
}

