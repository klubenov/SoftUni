using System;

namespace P13VowelOrDigit
{
    class P13VowelOrDigit
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            try
            {
                int digit = int.Parse(input);
                Console.WriteLine("digit");
            }
            catch (Exception)
            {
                if ("aouei".IndexOf(input) >= 0) Console.WriteLine("vowel");
                else Console.WriteLine("other");
            }
        }
    }
}