using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P09TeamworkProjects
{
    public class Team
    {
        public string Creator { get; set; }
        public List<string> Members { get; set; }
        public string Name { get; set; }
    }

    class P09TeamworkProjects
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Team> teams = new List<Team>();
            for (int i = 0; i < n; i++)
            {
                string[] createTeam = Console.ReadLine().Split('-');
                string creator = createTeam[0];
                string team = createTeam[1];
                Team newTeam = new Team();
                if (teams.Any(t => t.Name == team))
                {
                    Console.WriteLine($"Team {team} was already created!");
                }
                else if (teams.Any(c => c.Creator == creator))
                {
                    Console.WriteLine($"{creator} cannot create another team!");
                }
                else
                {
                    newTeam.Creator = creator;
                    newTeam.Name = team;
                    teams.Add(newTeam);
                    Console.WriteLine($"Team {team} has been created by {creator}!");
                }
            }
            foreach (var team in teams)
            {
                team.Members = new List<string>();
            }
            string input = Console.ReadLine();
            while (input != "end of assignment")
            {
                string[] membersAdd = input.Split(new char[] { '-', '>' }, StringSplitOptions.RemoveEmptyEntries);
                string member = membersAdd[0];
                string team = membersAdd[1];
                if (!teams.Any(t => t.Name==team))
                {
                    Console.WriteLine($"Team {team} does not exist!");
                    //input = Console.ReadLine();
                    //continue;
                }
                else if (teams.Any(x => x.Creator == member))
                {
                    Console.WriteLine($"Member {member} cannot join team {team}!");

                }
                else if (teams.Any(x => x.Members.Contains(member)))
                {
                    Console.WriteLine($"Member {member} cannot join team {team}!");
                }
                else
                {
                    foreach (var t in teams)
                    {
                        if (t.Name==team)
                        {
                            t.Members.Add(member);
                            break;
                        }
                    }
                }
                //int checker = 0;
                //foreach (var checkTeam in teams)
                //{
                //    if (teams.Any(x => x.Creator == member))
                //    {
                //        Console.WriteLine($"Member {member} cannot join team {team}!");
                //        checker++;
                //        break;
                //    }
                //    foreach (var checkMember in checkTeam.Members)
                //    {
                //        if (checkMember==member)
                //        {
                //            Console.WriteLine($"Member {member} cannot join team {team}!");
                //            input = Console.ReadLine();
                //            checker++;
                //            break;
                //        }
                //    }
                //    if (checker>0)
                //    {
                //        break;
                //    }
                //}
                //if (checker == 0)
                //{
                //    teams.FirstOrDefault(t => t.Name == team).Members.Add(member);
                //}
                //checker = 0;
                input = Console.ReadLine();
            }    
            List<Team> disbandList = new List<Team>();
            disbandList = teams.Where(t => t.Members.Count == 0).ToList();
            teams.RemoveAll(t => t.Members.Count == 0);
            foreach (var team in teams.OrderByDescending(x => x.Members.Count).ThenBy(x => x.Name))
            {
                //if (team.Members.Count==0)
                //{
                //    disbandList.Add(team);
                //    continue;
                //}
                Console.WriteLine(team.Name);
                Console.WriteLine($"- {team.Creator}");
                foreach (var member in team.Members.OrderBy(y => y))
                {
                    Console.WriteLine($"-- {member}");
                }
            }
            Console.WriteLine("Teams to disband:");
            foreach (var team in disbandList.OrderBy(x => x.Name))
            {
                Console.WriteLine(team.Name);
            }
        }
    }
}
