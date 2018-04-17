using System;

namespace P18DifferentIntegersSize
{
    class P18DifferentIntegersSize
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            try
            {
                long num = long.Parse(input);
                Console.WriteLine($"{num} can fit in:");
                if (-128 <= num && num <= 127) Console.WriteLine("* sbyte");
                if (0 <= num && num <= 255) Console.WriteLine("* byte");
                if (-32768 <= num && num <= 32767) Console.WriteLine("* short");
                if (0 <= num && num <= 65535) Console.WriteLine("* ushort");
                if (-2147483648 <= num && num <= 2147483647) Console.WriteLine("* int");
                if (0 <= num && num <= 4294967295) Console.WriteLine("* uint");
                Console.WriteLine("* long");
            }
            catch (Exception)
            {
                Console.WriteLine($"{input} can't fit in any type");
            }
        }
    }
}