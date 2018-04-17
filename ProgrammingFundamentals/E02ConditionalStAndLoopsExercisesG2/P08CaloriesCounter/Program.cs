using System;

namespace P08CaloriesCounter
{
    class Program
    {
        static void Main(string[] args)
        {
            var ingrCount = int.Parse(Console.ReadLine());
            var totalCal = 0;
            for (int i = 1; i <= ingrCount; i++)
            {
                string ingrType = Console.ReadLine().ToLower();
                if (ingrType == "cheese") totalCal += 500;
                else if (ingrType == "tomato sauce") totalCal += 150;
                else if (ingrType == "salami") totalCal += 600;
                else if (ingrType == "pepper") totalCal += 50;
            }
            Console.WriteLine($"Total calories: {totalCal}");
        }
    }
}
