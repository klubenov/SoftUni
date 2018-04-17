using System;
using System.Numerics;

namespace P14FactorialTrailingZeroes
{
    class P14FactorialTrailingZeroes
    {
        static int TrailingZeros(BigInteger num)
        {
            int zeroCount = 0;
            BigInteger currentDigit = num % 10;
            if (currentDigit == 0) zeroCount++;
            num = num / 10;
            while (currentDigit == 0)
            {
                currentDigit = num % 10;
                if (currentDigit == 0) zeroCount++;
                num = num / 10;
            }
            return zeroCount;
        }

        static void Main(string[] args)
        {
            long n = long.Parse(Console.ReadLine());
            BigInteger nFact = 1;
            for (int i = 1; i <= n; i++)
            {
                nFact = nFact * i;
            }
            Console.WriteLine(TrailingZeros(nFact));
        }
    }
}
