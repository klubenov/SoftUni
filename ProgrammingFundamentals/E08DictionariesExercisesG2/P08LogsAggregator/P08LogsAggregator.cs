using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P08LogsAggregator
{
    class P08LogsAggregator
    {
        static void Main(string[] args)
        {
            int entryCount = int.Parse(Console.ReadLine());
            SortedDictionary<string, SortedDictionary<string, int >> logs =
                new SortedDictionary<string, SortedDictionary<string, int>>();
            for (int i = 1; i <= entryCount; i++)
            {
                string input = Console.ReadLine();
                string[] commands = input.Split(' ');
                string ip = commands[0];
                string name = commands[1];
                int duration = int.Parse(commands[2]);
                if (!logs.ContainsKey(name))
                {
                    logs.Add(name, new SortedDictionary<string, int>());
                    logs[name].Add(ip,duration);
                }
                else
                {
                    if (!logs[name].ContainsKey(ip))
                    {
                        logs[name].Add(ip,duration);
                    }
                    else
                    {
                        logs[name][ip] = logs[name][ip] +duration;
                    }
                }
            }
            foreach (var name in logs)
            {
                Console.WriteLine($"{name.Key}: {name.Value.Values.Sum()} [{string.Join(", ", name.Value.Keys)}]");
            }
        }
    }
}
