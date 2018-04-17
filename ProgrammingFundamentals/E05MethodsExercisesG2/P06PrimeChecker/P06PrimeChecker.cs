using System;

namespace P06PrimeChecker
{
    class P06PrimeChecker
    {
        static bool IsPrime(long n)
        {
            if (n <= 1) return false;
            if (n == 2) return true;
            if (n % 2 == 0) return false;
            long m = (long)Math.Sqrt(n);

            for (long d = 3; d <= m; d += 2)
                if (n % d == 0)
                    return false;

            return true;
        }

        static void Main(string[] args)
        {
            Console.WriteLine(IsPrime(long.Parse(Console.ReadLine())));
        }
    }
}
