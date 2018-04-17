using System;
using System.Collections.Generic;
using System.Linq;

namespace P04_Hospital
{
    public class Program
    {
        public static void Main()
        {
            Dictionary<string, List<string>> doctorDictionary = new Dictionary<string, List<string>>();
            Dictionary<string, List<string>> departmentDictionary = new Dictionary<string, List<string>>();


            string command;
            while ((command=Console.ReadLine()) != "Output")
            {
                string[] commandTokens = command.Split();
                var departament = commandTokens[0];
                var doctorFullName = commandTokens[1] + commandTokens[2];
                var patientName = commandTokens[3];

                if (!doctorDictionary.ContainsKey(doctorFullName))
                {
                    doctorDictionary[doctorFullName] = new List<string>();
                }
                if (!departmentDictionary.ContainsKey(departament))
                {
                    departmentDictionary[departament] = new List<string>();
                    
                }

                bool departmentNotFull = departmentDictionary[departament].Count < 60;
                if (departmentNotFull)
                {
                    doctorDictionary[doctorFullName].Add(patientName);
                    departmentDictionary[departament].Add(patientName);
                }
            }

            while ((command=Console.ReadLine()) != "End")
            {
                string[] printCommands = command.Split();

                if (printCommands.Length == 1)
                {
                    var departmentToBePrinted = printCommands[0];
                    Console.WriteLine(string.Join("\n", departmentDictionary[departmentToBePrinted]));
                }
                else if (printCommands.Length == 2 && int.TryParse(printCommands[1], out int roomToBePrinted))
                {
                    var departmentToBePrinted = printCommands[0];
                    Console.WriteLine(string.Join("\n", departmentDictionary[departmentToBePrinted].Skip(3*(roomToBePrinted-1)).Take(3).OrderBy(x => x)));
                }
                else
                {
                    var doctorFilter = printCommands[0] + printCommands[1];
                    Console.WriteLine(string.Join("\n", doctorDictionary[doctorFilter].OrderBy(x => x)));
                }
            }
        }
    }
}
