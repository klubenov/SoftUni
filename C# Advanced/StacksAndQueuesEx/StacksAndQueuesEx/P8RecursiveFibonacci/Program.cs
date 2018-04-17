using System;

namespace P8RecursiveFibonacci
{
    class Program
    {
        private static long[] memoizationArr;

        public static void Main(string[] args)
        {
            long fibNum = long.Parse(Console.ReadLine());
            memoizationArr = new long[fibNum + 1];
            Console.WriteLine(GetFibonacci(fibNum));
        }

        public static long GetFibonacci(long n)
        {
            if (n<=2)
            {
                return 1;
            }
            if(memoizationArr[n]==0)
            {
                memoizationArr[n] = GetFibonacci(n - 1) + GetFibonacci(n - 2);
            }

            return memoizationArr[n];
        }
    }
}
