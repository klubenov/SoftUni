using System;

namespace P10TriangleOfNumbers
{
    class P10TriangleOfNumbers
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            for (int i = 1; i <= n; i++)
            {
                for (int j = 1;j <= i; j++)
                {
                    if (j==i) Console.WriteLine($"{i} ");
                    else Console.Write($"{i} ");
                }
            }
        }
    }
}
