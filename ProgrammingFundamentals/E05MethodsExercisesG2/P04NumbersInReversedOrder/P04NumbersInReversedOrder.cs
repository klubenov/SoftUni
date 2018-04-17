using System;

namespace P04NumbersInReversedOrder
{
    class P04NumbersInReversedOrder
    {
        static string ReverseDecimalText(string decNum)
        {
            char[] standardOrder = decNum.ToCharArray();
            Array.Reverse(standardOrder);
            return new string(standardOrder);
        }

        static void Main(string[] args)
        {
            string decNum = Console.ReadLine();
            Console.WriteLine(ReverseDecimalText(decNum));
        }
    }
}
