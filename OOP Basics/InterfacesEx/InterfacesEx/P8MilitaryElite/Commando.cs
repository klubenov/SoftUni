using System;
using System.Collections.Generic;
using System.Text;


public class Commando : SpecialisedSoldier, ICommando
{
    public List<Mission> MissionList { get; set; }

    public Commando(string id, string firstName, string lastName, decimal salary, string corps, List<Mission> missionList) : base(id, firstName,
        lastName, salary, corps)
    {
        MissionList = missionList;
    }

    public override string ToString()
    {
        var missionSb = new StringBuilder();

        foreach (var commandoMission in MissionList)
        {
            if (commandoMission==MissionList[MissionList.Count-1])
            {
                missionSb.Append("  ").Append(commandoMission);
            }
            else
            {
                missionSb.Append("  ").Append(commandoMission).AppendLine();
            }
        }

        return $"Name: {FirstName} {LastName} Id: {Id} Salary: {Salary:f2}\r\nCorps: {Corps}\r\nMissions:\r\n{missionSb}".TrimEnd();
    }
}

