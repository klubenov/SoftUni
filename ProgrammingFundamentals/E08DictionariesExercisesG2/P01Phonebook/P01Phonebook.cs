using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01Phonebook
{
    class P01Phonebook
    {
        static void Main(string[] args)
        {
            var commands = Console.ReadLine().Split(' ').ToArray();
            var phonebook = new Dictionary<string,string>();
            while (commands[0] != "END")
            {
                switch (commands[0])
                {
                    case "A":
                        if (phonebook.ContainsKey(commands[1]))
                        {
                            phonebook[commands[1]] = commands[2];
                        }
                        else
                        {
                            phonebook.Add(commands[1], commands[2]);
                        }
                        break;
                    case "S":
                        if (phonebook.ContainsKey(commands[1]))
                        {
                            Console.WriteLine($"{commands[1]} -> {phonebook[commands[1]]}");                            
                        }
                        else
                        {
                            Console.WriteLine($"Contact {commands[1]} does not exist.");
                        }
                        break;
                }
                commands = Console.ReadLine().Split(' ').ToArray();
            }
        }
    }
}
