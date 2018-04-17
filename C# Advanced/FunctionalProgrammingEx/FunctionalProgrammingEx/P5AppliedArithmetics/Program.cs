using System;
using System.Linq;

namespace P5AppliedArithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            var nums = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            string input = Console.ReadLine();
            while (input != "end")
            {
                switch (input)
                {
                    case "add":
                        nums = nums.Select(n => n + 1).ToArray();
                        break;
                    case "subtract":
                        nums = nums.Select(n => n - 1).ToArray();
                        break;
                    case "multiply":
                        nums = nums.Select(n => n * 2).ToArray();
                        break;
                    case "print":
                        Console.WriteLine(string.Join(" ", nums));
                        break;
                }
                input = Console.ReadLine();
            }
        }
    }
}
