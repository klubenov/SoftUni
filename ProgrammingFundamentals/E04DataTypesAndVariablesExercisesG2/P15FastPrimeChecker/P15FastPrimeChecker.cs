using System;

namespace P15FastPrimeChecker
{
    class P15FastPrimeChecker
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 2; i <= n; i++)
            {
                bool ifPrime = IsPrime(i);
                if (ifPrime) Console.WriteLine($"{i} -> {ifPrime}");
                else Console.WriteLine($"{i} -> {ifPrime}");
            }
        }
        static bool IsPrime(int n)
        {
            if (n <= 1) return false;
            if (n == 2) return true;
            if (n % 2 == 0) return false;
            int m = (int)Math.Sqrt(n);

            for (int d = 3; d <= m; d += 2)
                if (n % d == 0)
                    return false;

            return true;
        }
    }
}
