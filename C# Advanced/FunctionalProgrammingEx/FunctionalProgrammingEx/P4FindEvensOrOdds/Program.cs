using System;
using System.Collections.Generic;
using System.Linq;

namespace P4FindEvensOrOdds
{
    class Program
    {
        static void Main(string[] args)
        {
            var range = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var numbers = new List<int>();
            for (int i = range[0]; i <= range[1]; i++)
            {
                numbers.Add(i);
            }
            var filterType = Console.ReadLine();
            Predicate<int> even = n => n % 2 == 0;
            Predicate<int> odd = n => n % 2 != 0;
            if (filterType == "even")
            {
                var print = numbers.Where(n => even(n)).ToList();
                Console.WriteLine(string.Join(" ", print));
            }
            else if (filterType == "odd")
            {
                var print = numbers.Where(n => odd(n)).ToList();
                Console.WriteLine(string.Join(" ", print));
            }
        }
    }
}
