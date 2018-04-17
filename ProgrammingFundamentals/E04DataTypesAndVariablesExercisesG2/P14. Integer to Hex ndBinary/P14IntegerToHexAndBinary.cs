using System;

namespace P14IntegerToHexAndBinary
{
    class P14IntegerToHexAndBinary
    {
        static void Main(string[] args)
        {
            int intNum = int.Parse(Console.ReadLine());
            string hexNum = intNum.ToString("X");
            string binaryNum = Convert.ToString(intNum, 2);
            Console.WriteLine($"{hexNum}\n{binaryNum}");
        }
    }
}
