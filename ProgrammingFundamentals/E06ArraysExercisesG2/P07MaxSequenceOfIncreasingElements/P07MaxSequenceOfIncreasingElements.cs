using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P07MaxSequenceOfIncreasingElements
{
    class P07MaxSequenceOfIncreasingElements
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int start = 0;
            int bestStart = 0;
            int length = 1;
            int bestLenght = 0;
            for (int i = 1; i <= arr.Length - 1; i++)
            {
                if (arr[i] > arr[i - 1])
                {
                    length++;
                    if (length > bestLenght)
                    {
                        bestStart = start;
                        bestLenght = length;
                    }
                }
                else
                {
                    start = i;
                    length = 1;
                }

            }
            for (int i = bestStart; i <= bestStart + bestLenght - 1; i++)
            {
                Console.Write($"{arr[i]} ");
            }
        }
    }
}
