using System;

namespace BeverageLevels
{
    class Program
    {
        static void Main(string[] args)
        {
            string bevName = Console.ReadLine();
            var vol = double.Parse(Console.ReadLine());
            var enContent = int.Parse(Console.ReadLine());
            var sugContent = int.Parse(Console.ReadLine());
            var volQuotient = vol / 100;
            Console.WriteLine($"{vol}ml {bevName}:");
            Console.WriteLine($"{volQuotient * enContent}kcal, {volQuotient * sugContent}g sugars");
        }
    }
}
