using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace P06UserLogs
{
    class P06UserLogs
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            var userMessages = new SortedDictionary<string, List<string>>();
            while (input != "end")
            {
                string[] ipS = input.Split(' ').ToArray();
                ipS[0] = ipS[0].Remove(0, 3);
                ipS[2] = ipS[2].Remove(0, 5);
                if (!userMessages.ContainsKey(ipS[2]))
                {
                    userMessages[ipS[2]] = new List<string> { ipS[0] };
                }
                else
                {
                    userMessages[ipS[2]].Add(ipS[0]);
                }
                input = Console.ReadLine();
            }
            foreach (var user in userMessages)
            {
                var ipCount = user.Value.GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());
                Console.WriteLine($"{user.Key}:");
                StringBuilder ipList = new StringBuilder();
                foreach (var ip in ipCount)
                {
                    ipList.Append(ip.Key).Append(" => ").Append(ip.Value).Append(", ");
                }
                ipList.Remove(ipList.Length - 2, 2);
                Console.WriteLine($"{ipList}.");
            }
        }
    }
}
