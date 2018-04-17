using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P02PhonebookUpgrade
{
    class P02PhonebookUpgrade
    {
        static void Main(string[] args)
        {
            var commands = Console.ReadLine().Split(' ').ToArray();
            var phonebook = new SortedDictionary<string, string>();
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
                    case "ListAll":
                        
                        foreach (var name in phonebook)
                        {
                            Console.WriteLine($"{name.Key} -> {name.Value}");
                        }
                        break;
                }
                commands = Console.ReadLine().Split(' ').ToArray();
            }
        }
    }
}
