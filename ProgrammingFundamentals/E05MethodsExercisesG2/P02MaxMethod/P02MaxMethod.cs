using System;

namespace P02MaxMethod
{
    class P02MaxMethod
    {
        static int GetMax(int a, int b)
        {
            return Math.Max(a, b);
        }

        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            int num3 = int.Parse(Console.ReadLine());
            int maxOfnum1andnum2 = GetMax(num1, num2);
            Console.WriteLine(GetMax(maxOfnum1andnum2,num3));
        }
    }
}
