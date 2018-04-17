using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace P11PoisonousPlants
{
    class Program
    {
        static void Main(string[] args)
        {
            int plantQty = int.Parse(Console.ReadLine());
            
            var plants = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            var deathDays = new int[plantQty];
            var previousPlants = new Stack<int>();
            previousPlants.Push(0);

            for (int i = 1; i < plantQty; i++)
            {
                int lastDay = 0;

                while (previousPlants.Count()>0 && plants[previousPlants.Peek()]>=plants[i])
                {
                    lastDay = Math.Max(lastDay,deathDays[previousPlants.Pop()]);
                }
                if (previousPlants.Count() > 0)
                {
                    deathDays[i] = lastDay + 1;
                }
                previousPlants.Push(i);
            }
            Console.WriteLine(deathDays.Max());
        }
    }
}
