using System;
using System.Collections.Generic;
using System.Text;


public class Engineer : SpecialisedSoldier, IEngineer
{
    public List<Repairs> RepairsList { get; set; }

    public Engineer(string id, string firstName, string lastName, decimal salary, string corps, List<Repairs> repairsList) : base(id, firstName,
        lastName, salary, corps)
    {
        RepairsList = repairsList;
    }

    public override string ToString()
    {
        var repairsSb = new StringBuilder();

        foreach (var repair in RepairsList)
        {
            if (repair==RepairsList[RepairsList.Count-1])
            {
                repairsSb.Append("  ").Append(repair);
            }
            else
            {
                repairsSb.Append("  ").Append(repair).AppendLine();
            }
        }

        return $"Name: {FirstName} {LastName} Id: {Id} Salary: {Salary:f2}\r\nCorps: {Corps}\r\nRepairs:\r\n{repairsSb}".TrimEnd();
    }
}

