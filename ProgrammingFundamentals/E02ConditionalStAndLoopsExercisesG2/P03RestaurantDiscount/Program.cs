using System;

namespace P03RestaurantDiscount
{
    class Program
    {
        static void Main(string[] args)
        {
            var groupSize = int.Parse(Console.ReadLine());
            string discountType = Console.ReadLine();
            var finalPrice = 0.0;
            if (groupSize > 120)
            {
                Console.WriteLine("We do not have an appropriate hall.");
                return;
            }
            else if (groupSize <= 50)
            {
                finalPrice = 2500;
                Console.WriteLine("We can offer you the Small Hall");
            }
            else if (groupSize <= 100)
            {
                finalPrice = 5000;
                Console.WriteLine("We can offer you the Terrace");
            }
            else
            {
                finalPrice = 7500;
                Console.WriteLine("We can offer you the Great Hall");
            }
            if (discountType == "Normal") Console.WriteLine($"The price per person is {(0.95 * (finalPrice + 500)) / groupSize:f2}$");
            else if (discountType == "Gold") Console.WriteLine($"The price per person is {(0.9 * (finalPrice + 750)) / groupSize:f2}$");
            else if (discountType == "Platinum") Console.WriteLine($"The price per person is {(0.85 * (finalPrice + 1000)) / groupSize:f2}$");
        }
    }
}
