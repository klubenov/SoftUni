using System;
using System.Collections.Generic;
using System.Linq;

namespace P1ReverseNumbersWithAStack
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split(' ');

            var stackNums = new Stack<string>(numbers);
            int stackNumsLength = stackNums.Count;

            for (int i = 0; i < stackNumsLength; i++)
            {
                Console.Write(stackNums.Pop() + " ");
            }
        }
    }
}