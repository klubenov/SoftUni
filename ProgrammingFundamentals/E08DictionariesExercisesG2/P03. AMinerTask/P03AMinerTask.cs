using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P03AMinerTask
{
    class P03AMinerTask
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string previousInput = "";
            int commandCount = 1;
            var resources = new Dictionary<string, int>();
            while (input != "stop")
            {
                if (commandCount % 2 == 1)
                {
                    if(!resources.ContainsKey(input)) resources.Add(input,0);
                }
                else
                {
                    resources[previousInput] += int.Parse(input);
                }
                previousInput = input;
                input = Console.ReadLine();
                commandCount++;
            }
            foreach (var resource in resources)
            {
                Console.WriteLine($"{resource.Key} -> {resource.Value}");
            }
        }
    }
}
