using System;

namespace P06IntervalOfNumbers
{
    class P06IntervalOfNumbers
    {
        static void Main(string[] args)
        {
            var firstNum = int.Parse(Console.ReadLine());
            var secondNum = int.Parse(Console.ReadLine());
            var minNum = Math.Min(firstNum, secondNum);
            var maxNum = Math.Max(firstNum, secondNum);
            for (int i = minNum; i <= maxNum; i++)
            {
                Console.WriteLine(i);
            }
        }
    }
}
