using System;
using System.Collections.Generic;

namespace P4ShoppingSpree
{
    class Program
    {
        static void Main(string[] args)
        {
            var personData = Console.ReadLine().Split(new char[] { '=', ';' }, StringSplitOptions.RemoveEmptyEntries);
            var productData = Console.ReadLine().Split(new char[] { '=', ';' }, StringSplitOptions.RemoveEmptyEntries);

            var personDict = new Dictionary<string, Person>();
            var productDict = new Dictionary<string, Product>();

            try
            {
                for (int i = 0; i < personData.Length; i += 2)
                {
                    var personName = personData[i];
                    var personMoney = decimal.Parse(personData[i + 1]);
                    var newPerson = new Person(personName, personMoney);
                    personDict.Add(personName, newPerson);
                }

                for (int i = 0; i < productData.Length; i += 2)
                {

                    var productName = productData[i];
                    var productCost = decimal.Parse(productData[i + 1]);
                    var newProduct = new Product(productName, productCost);
                    productDict.Add(productName, newProduct);

                }
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
                return;
            }

            string input;

            while ((input = Console.ReadLine()) != "END")
            {
                var purchaseData = input.Split(' ');

                var client = purchaseData[0];
                var purchase = purchaseData[1];

                if (personDict[client].Money >= productDict[purchase].Cost)
                {
                    personDict[client].BagList.Add(productDict[purchase]);
                    personDict[client].Money -= productDict[purchase].Cost;
                    Console.WriteLine($"{client} bought {purchase}");
                }
                else
                {
                    Console.WriteLine($"{client} can't afford {purchase}");
                }
            }

            foreach (var person in personDict)
            {
                Console.WriteLine(person.Value);
            }
        }
    }
}
