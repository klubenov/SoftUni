using System;
using System.Collections.Generic;
using System.Linq;

namespace P7BalancedParentheses
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] input = Console.ReadLine().ToCharArray();

            if (input.Length % 2 !=0)
            {
                Console.WriteLine("NO");
                Environment.Exit(0);
            }

            char[] opening = new [] {'(','[','{'};
            char[] closing = new[] {')', ']', '}'};

            var stack = new Stack<char>();

            foreach (var bracket in input)
            {
                if (opening.Contains(bracket))
                {
                    stack.Push(bracket);
                }
                else if (closing.Contains(bracket))
                {
                    var lastBracket = stack.Pop();
                    int openingIndex = Array.IndexOf(opening, lastBracket);
                    int closingIndex = Array.IndexOf(closing, bracket);

                    if (openingIndex != closingIndex)
                    {
                        Console.WriteLine("NO");
                        Environment.Exit(0);
                    }
                }
            }

            if (stack.Any())
            {
                Console.WriteLine("NO");
            }
            else
            {
                Console.WriteLine("YES");
            }
        }
    }
}
