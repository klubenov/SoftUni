using System;

namespace P04VariableInHexFormat
{
    class P04VariableInHexFormat
    {
        static void Main(string[] args)
        {
            string hexNum = Console.ReadLine();
            Console.WriteLine(Convert.ToInt32(hexNum, 16));
        }
    }
}