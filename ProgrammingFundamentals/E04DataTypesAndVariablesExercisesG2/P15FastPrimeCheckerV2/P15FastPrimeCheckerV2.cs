using System;

namespace P15FastPrimeCheckerV2
{
    class Program
    {
        static void Main(string[] args)
        {
            int maxNum = int.Parse(Console.ReadLine());
            for (int currentNum = 2; currentNum <= maxNum; currentNum++)
            {
                bool isPrime = true;
                for (int divideNum = 2; divideNum <= Math.Sqrt(currentNum); divideNum++)
                {
                    if (currentNum % divideNum == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }
                Console.WriteLine($"{currentNum} -> {isPrime}");
            }

        }
    }
}