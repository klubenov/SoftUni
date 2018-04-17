using System;
using System.Collections.Generic;
using System.Linq;

namespace P2BasicStackOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            var firstLine = Console.ReadLine().Split(' ');

            int numberCount = int.Parse(firstLine[0]);
            int popCount = int.Parse(firstLine[1]);
            string numberToBeFound = firstLine[2];

            Stack<string> numStack = new Stack<string>(Console.ReadLine().Split(' '));

            for (int i = 0; i < popCount; i++)
            {
                numStack.Pop();
            }

            if (numStack.Count == 0)
            {
                Console.WriteLine(0);
            }
            else if (numStack.Contains(numberToBeFound))
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine(numStack.Min());
            }
        }
    }
}
