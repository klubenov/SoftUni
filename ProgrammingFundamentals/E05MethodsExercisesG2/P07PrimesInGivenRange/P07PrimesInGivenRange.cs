using System;
using System.Collections.Generic;

namespace P07PrimesInGivenRange
{
    class P07PrimesInGivenRange
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

        static List<int> PrimesInRange(int startNum, int endNum)
        {
            List<int> primes = new List<int>();
            for (int i = startNum; i <= endNum; i++)
            {
                if (IsPrime(i)) primes.Add(i);
            }
            return primes;
        }

        static void Main(string[] args)
        {
            int startNum = int.Parse(Console.ReadLine());
            int endNum = int.Parse(Console.ReadLine());
            string primesList = string.Join(", ", PrimesInRange(startNum, endNum));
            Console.WriteLine(primesList);
        }
    }
}
