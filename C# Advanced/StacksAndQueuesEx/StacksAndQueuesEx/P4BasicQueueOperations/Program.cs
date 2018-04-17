using System;
using System.Collections.Generic;
using System.Linq;

namespace P4BasicQueueOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputLine = Console.ReadLine().Split(' ');
            var numberCount = int.Parse(inputLine[0]);
            var numberToBeDequeuedCount = int.Parse(inputLine[1]);
            var numberToBeFound = inputLine[2];

            var numbers = Console.ReadLine().Split(' ');

            var queue = new Queue<string>();

            for (int i = 0; i < numberCount; i++)
            {
                queue.Enqueue(numbers[i]);
            }

            for (int i = 0; i < numberToBeDequeuedCount; i++)
            {
                queue.Dequeue();
            }

            if (queue.Count==0)
            {
                Console.WriteLine(0);
            }
            else if (queue.Contains(numberToBeFound))
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine(queue.Min());
            }
        }
    }
}
