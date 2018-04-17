using System;
using System.Collections.Generic;
using System.Linq;

namespace P6ReverseAndExclude
{
    class Program
    {
        static void Main(string[] args)
        {
            var nums = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int divider = int.Parse(Console.ReadLine());

            Func<int[], int, int[]> filterByDivision = (numArr, dividerNum) =>
            {
                Predicate<int> filter = n => n % dividerNum != 0;
                int[] filteredArr = numArr.Where(n => filter(n)).ToArray();
                return filteredArr;
            };
            Func<int[], int[]> reverseArr = numArr =>
            {
                int[] reversedArr = new int[numArr.Length];
                var reverseQueue = new Queue<int>();
                for (int i = numArr.Length - 1; i >= 0; i--)
                {
                    reverseQueue.Enqueue(numArr[i]);
                }
                int queueCount = reverseQueue.Count;
                for (int i = 0; i < queueCount; i++)
                {
                    reversedArr[i] = reverseQueue.Dequeue();
                }
                return reversedArr;
            };

            Console.WriteLine(string.Join(" ", reverseArr(filterByDivision(nums, divider))));
        }
    }
}
