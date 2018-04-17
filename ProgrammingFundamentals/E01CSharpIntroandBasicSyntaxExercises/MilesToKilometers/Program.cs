using System;

namespace MilesToKilometers
{
    class Program
    {
        static void Main(string[] args)
        {
            var miles = double.Parse(Console.ReadLine());
            var kmeters = miles * 1.60934;
            Console.WriteLine($"{kmeters:f2}");
        }
    }
}
