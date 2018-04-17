using System;

namespace P16ComparingFloats
{
    class Program
    {
        static void Main(string[] args)
        {
            double firstNum = double.Parse(Console.ReadLine());
            double secondNum = double.Parse(Console.ReadLine());
            double epsilon = Math.Abs(firstNum - secondNum);
            if (epsilon < 0.000001)
                Console.WriteLine("True");
            else Console.WriteLine("False");
        }
    }
}