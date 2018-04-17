using System;
using System.Collections.Generic;

namespace P9StackFibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            var fibonacciStack = new Stack<long>(new long[]{0,1});
            long currFibNum = 0;

            int fibCount = int.Parse(Console.ReadLine());

            if (fibCount==0)
            {
                Console.WriteLine(0);
                return;
            }
            if (fibCount==1||fibCount==2)
            {
                Console.WriteLine(1);
                return;;
            }

            for (int i = 0; i < fibCount-1; i++)
            {
                long prevFibNum;
                prevFibNum = fibonacciStack.Pop();
                currFibNum = prevFibNum + fibonacciStack.Peek();
                fibonacciStack.Push(prevFibNum);
                fibonacciStack.Push(currFibNum);

            }
            Console.WriteLine(currFibNum);
        }
    }
}
