using System;

namespace P05FibonacciNumbers
{
    class P05FibonacciNumbers
    {
        static int FibPositionNum(int positionCount)
        {
            int previousFib = 0;
            int currentFib = 1;
            for (int i = 1; i <= positionCount; i++)
            {
                int currentFibtemp = currentFib;
                currentFib = currentFib + previousFib;
                previousFib = currentFibtemp;
            }
            if (positionCount == 0)
                return 1;
            else return currentFib;
        }

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine(FibPositionNum(n));
        }
    }
}
