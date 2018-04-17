using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01MaxSequenceOfEqualElements
{
    class P01MaxSequenceOfEqualElements
    {
        static void Main(string[] args)
        {
            List<int> numList = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            int start = 0;
            int bestStart = 0;
            int length = 1;
            int bestLenght = 1;
            for (int i = 1; i <= numList.Count - 1; i++)
            {
                if (numList[i] == numList[i - 1])
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
                Console.Write($"{numList[i]} ");
            }
        }
    }
}