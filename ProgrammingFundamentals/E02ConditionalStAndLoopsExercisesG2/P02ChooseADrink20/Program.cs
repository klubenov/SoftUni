using System;

namespace P02ChooseADrink20
{
    class Program
    {
        static void Main(string[] args)
        {
            string profType = Console.ReadLine();
            var qty = int.Parse(Console.ReadLine());
            if (profType == "Athlete") Console.WriteLine($"The Athlete has to pay {0.7*qty:f2}.");
            else if (profType == "Businessman") Console.WriteLine($"The Businessman has to pay {1.0*qty:f2}.");
            else if (profType == "Businesswoman") Console.WriteLine($"The Businesswoman has to pay {1.0*qty:f2}.");
            else if (profType == "SoftUni Student") Console.WriteLine($"The SoftUni Student has to pay {1.7*qty:f2}.");
            else Console.WriteLine($"The {profType} has to pay {1.2*qty:f2}.");
        }
    }
}
