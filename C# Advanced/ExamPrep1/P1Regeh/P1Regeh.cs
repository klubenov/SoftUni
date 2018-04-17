using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace P1Regeh
{
    class P1Regeh
    {
        static void Main(string[] args)
        {
            string pattern = @"[A-Za-z]+<(\d+)REGEH(\d+)>[A-Za-z]+";
            string input = Console.ReadLine();
            Regex regex = new Regex(pattern);
            MatchCollection matches = regex.Matches(input);
            
            List<int> indexes = new List<int>();
            int currentSumOfNumbers = 0;

            foreach (Match match in matches)
            {
                int firstMatch = int.Parse(match.Groups[1].Value);
                int secondMatch = int.Parse(match.Groups[2].Value);
                int firstIndex = firstMatch + currentSumOfNumbers;
                indexes.Add(firstIndex);
                currentSumOfNumbers += firstMatch;
                int secondIndex = secondMatch + currentSumOfNumbers;
                indexes.Add(secondIndex);
                currentSumOfNumbers += secondMatch;
            }
            foreach (var index in indexes)
            {
                try
                {
                    Console.Write(input[index]);
                }
                catch (IndexOutOfRangeException)
                {
                    int outOfRangeIndex = index % (input.Length - 1);
                    Console.WriteLine(input[outOfRangeIndex]);
                }
            }
        }
    }
}
