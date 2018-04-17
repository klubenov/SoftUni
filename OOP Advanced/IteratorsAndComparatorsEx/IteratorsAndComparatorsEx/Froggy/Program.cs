using System;
using System.Collections.Generic;
using System.Linq;

namespace Froggy
{
    class Program
    {
        static void Main(string[] args)
        {
            var stones = Console.ReadLine()
                .Split(new[] {',', ' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var lake = new Lake(stones);

            var jumpList = new List<int>();
            foreach (var stone in lake)
            {
                jumpList.Add(stone);
            }
            Console.WriteLine(string.Join(", ", jumpList));
        }
    }
}
