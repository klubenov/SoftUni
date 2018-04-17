using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P7PredicateForNames
{
    class Program
    {
        static void Main(string[] args)
        {
            int maxNameLength = int.Parse(Console.ReadLine());
            var names = Console.ReadLine().Split(' ');
            Func<string[], int, string> printNames = (namesArr, maxNameLengthValue) =>
            {
                Predicate<string> filter = s => s.Length <= maxNameLengthValue;
                var fileteredNames = namesArr.Where(s => filter(s)).ToList();
                var result = new StringBuilder();
                foreach (var name in fileteredNames)
                {
                    result.Append(name).AppendLine();
                }
                return result.ToString().Trim();
            };
            Console.WriteLine(printNames(names, maxNameLength));
        }
    }
}
