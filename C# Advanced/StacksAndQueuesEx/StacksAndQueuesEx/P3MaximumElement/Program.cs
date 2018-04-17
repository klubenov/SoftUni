using System;
using System.Collections.Generic;

namespace P3MaximumElement
{
    class Program
    {
        static void Main(string[] args)
        {
            int commandCount = int.Parse(Console.ReadLine());

            var numStack = new Stack<int>();
            var maxNumStack = new Stack<int>();

            for (int i = 0; i < commandCount; i++)
            {
                string input = Console.ReadLine();

                if (input.StartsWith("1"))
                {
                    var commandArgs = input.Split(' ');
                    int number = int.Parse(commandArgs[1]);
                    numStack.Push(number);
                    if (maxNumStack.Count == 0)
                    {
                        maxNumStack.Push(number);
                    }
                    else if (number > maxNumStack.Peek())
                    {
                        maxNumStack.Push(number);
                    }
                }
                else if (input == "2")
                {
                    int poppedNum = numStack.Pop();
                    if (maxNumStack.Peek() == poppedNum)
                    {
                        maxNumStack.Pop();
                    }

                }
                else if (input == "3")
                {
                    Console.WriteLine(maxNumStack.Peek());
                }
            }
        }
    }
}