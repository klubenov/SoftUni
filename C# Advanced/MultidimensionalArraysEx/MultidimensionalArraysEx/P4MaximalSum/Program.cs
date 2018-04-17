using System;
using System.Linq;

namespace P4MaximalSum
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int rows = input[0];
            var columns = input[1];
            int[,] matrix = new int[rows, columns];
            for (int i = 0; i < rows; i++)
            {
                int[] numbers = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                for (int j = 0; j < columns; j++)
                {
                    matrix[i, j] = numbers[j];
                }
            }

            int maxSum = 0;
            int[] maxSumIndex = new int[2];
            for (int i = 0; i < rows-2; i++)
            {
                for (int j = 0; j < columns-2; j++)
                {
                    int tempSum = 0;
                    tempSum = matrix[i, j] + matrix[i, j+1] + matrix[i, j+2]
                            + matrix[i+1, j] + matrix[i+1, j+1] + matrix[i+1, j+2]
                            + matrix[i+2, j] + matrix[i+2, j+1] + matrix[i+2, j+2];
                    if (tempSum>maxSum)
                    {
                        maxSum = tempSum;
                        maxSumIndex[0] = i;
                        maxSumIndex[1] = j;
                    }
                }
            }
            Console.WriteLine($"Sum = {maxSum}");
            for (int i = maxSumIndex[0]; i < maxSumIndex[0]+3; i++)
            {
                for (int j = maxSumIndex[1]; j < maxSumIndex[1]+3; j++)
                {
                    Console.Write(matrix[i,j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
