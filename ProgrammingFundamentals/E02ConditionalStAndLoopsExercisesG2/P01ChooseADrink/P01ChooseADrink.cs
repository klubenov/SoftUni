using System;

namespace P01ChooseADrink
{
    class P01ChooseADrink
    {
        static void Main(string[] args)
        {
            string profType = Console.ReadLine();
            if (profType == "Athlete") Console.WriteLine("Water");
            else if (profType == "Businessman") Console.WriteLine("Coffee");
            else if (profType== "Businesswoman") Console.WriteLine("Coffee");
            else if (profType=="SoftUni Student") Console.WriteLine("Beer");
            else Console.WriteLine("Tea");
        }
    }
}
