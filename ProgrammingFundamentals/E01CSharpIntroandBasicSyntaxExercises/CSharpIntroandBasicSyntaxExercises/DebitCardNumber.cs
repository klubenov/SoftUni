using System;

namespace DebitCardNumber
{
    class DebitCardNumber
    {
        static void Main(string[] args)
        {
            var a = int.Parse(Console.ReadLine());
            var b = int.Parse(Console.ReadLine());
            var c = int.Parse(Console.ReadLine());
            var d = int.Parse(Console.ReadLine());
            Console.WriteLine("{0:d4} {1:d4} {2:d4} {3:d4}", a, b, c, d);
        }
    }
}
