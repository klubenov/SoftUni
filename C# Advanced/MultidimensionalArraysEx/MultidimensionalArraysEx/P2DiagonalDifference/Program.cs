using System;
using System.Linq;
using System.Numerics;

namespace P2DiagonalDifference
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            long[,] matrix = new long[n, n];
            long[] numbers = new long[n];
            for (int i = 0; i < n; i++)
            {
                numbers = Console.ReadLine().Split(new []{' '}, StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToArray();
                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = numbers[j];
                }
            }

            long firstDiag = 0;
            long secondDiag = 0;

            for (int i = 0; i < n; i++)
            {
                firstDiag += matrix[i, i];
            }
            for (int i = 0; i < n; i++)
            {
                secondDiag += matrix[i, n - 1 - i];
            }

            Console.WriteLine(Math.Abs(firstDiag-secondDiag));
        }
    }
}
