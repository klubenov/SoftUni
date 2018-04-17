using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P10SerbianUnleashed
{
    class P10SerbianUnleashed
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> venueDict = new Dictionary<string, Dictionary<string, int>>();
            string input = Console.ReadLine();
            while (input!="End")
            {
                if (!input.Contains(" @"))
                {
                    input = Console.ReadLine();
                    continue;
                }
                string[] singerInfo = input.Split(' ');
                int ticketCount = 0;
                int ticketPrice = 0;
                try
                {
                    ticketCount = int.Parse(singerInfo[singerInfo.Length - 1]);
                    ticketPrice = int.Parse(singerInfo[singerInfo.Length - 2]);
                }
                catch (Exception)
                {
                    input = Console.ReadLine();
                    continue;
                }
                string singer = "";
                string venue = "";
                for (int i = 0; i <= singerInfo.Length-3; i++)
                {
                    if (!singerInfo[i].Contains("@"))
                    {
                        singer = singer + singerInfo[i] + " ";
                    }
                    else
                    {
                        for (int j = i; j <= singerInfo.Length - 3; j++)
                        {
                            venue = venue + singerInfo[j] + " ";
                        }
                        break;
                    }
                }
                singer = singer.Remove(singer.Length - 1, 1);
                venue = venue.Remove(venue.Length - 1, 1).Remove(0, 1);
                if (!venueDict.ContainsKey(venue))
                {
                    venueDict.Add(venue, new Dictionary<string, int>());
                    venueDict[venue].Add(singer, ticketCount*ticketPrice);
                }
                else if (!venueDict[venue].ContainsKey(singer))
                {
                    venueDict[venue].Add(singer, ticketCount * ticketPrice);
                }
                else
                {
                    venueDict[venue][singer] += ticketCount * ticketPrice;
                }
                input = Console.ReadLine();
            }
            foreach (var venue in venueDict)
            {
                Console.WriteLine(venue.Key);
                foreach (var singer in venue.Value.Distinct().OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"#  {singer.Key} -> {singer.Value}");
                }
            }
        }
    }
}
