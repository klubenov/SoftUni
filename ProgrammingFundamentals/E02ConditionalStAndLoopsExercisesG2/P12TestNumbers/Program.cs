using System;

namespace P12TestNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var m = int.Parse(Console.ReadLine());
            var maxSum = int.Parse(Console.ReadLine());
            var combCount = 0;
            var currentSum = 0;
            for (int i = n; i >= 1; i--)
            {
                for (int j = 1; j <= m; j++)
                {
                    combCount++;
                    currentSum = currentSum + 3 * i * j;
                    if (currentSum >= maxSum)
                    {
                        Console.WriteLine($"{combCount} combinations");
                        Console.WriteLine($"Sum: {currentSum} >= {maxSum}");
                        return;
                    }
                }
            }
            Console.WriteLine($"{combCount} combinations");
            Console.WriteLine($"Sum: {currentSum}");
        }
    }
}
