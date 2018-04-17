using System;

namespace P04Hotel
{
    class Program
    {
        static void Main(string[] args)
        {
            string month = Console.ReadLine();
            var nightQty = int.Parse(Console.ReadLine());
            var nightQtyStudio = nightQty;
            var priceStudio = 0.0;
            var priceDouble = 0.0;
            var priceSuite = 0.0;
            switch (month)
            {
                case "October":
                case "May":
                    priceStudio = 50;
                    priceDouble = 65;
                    priceSuite = 75;
                    if (nightQty > 7) priceStudio = priceStudio * 0.95;
                    if (month == "October" && nightQty>7) nightQtyStudio -= 1;
                    break;
                case "June":
                case "September":
                    priceStudio = 60;
                    priceDouble = 72;
                    priceSuite = 82;
                    if (nightQty > 14) priceDouble = priceDouble * 0.9;
                    if (month == "September" && nightQty > 7) nightQtyStudio -= 1;
                    break;
                case "July":
                case "August":
                case "December":
                    priceStudio = 68;
                    priceDouble = 77;
                    priceSuite = 89;
                    if (nightQty > 14) priceSuite = priceSuite * 0.85;
                    break;            
            }
            Console.WriteLine($"Studio: {priceStudio*nightQtyStudio:f2} lv.");
            Console.WriteLine($"Double: {priceDouble*nightQty:f2} lv.");
            Console.WriteLine($"Suite: {priceSuite*nightQty:f2} lv.");
        }
    }
}
