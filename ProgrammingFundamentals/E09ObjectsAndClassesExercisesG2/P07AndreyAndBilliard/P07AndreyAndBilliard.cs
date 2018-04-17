using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P07AndreyAndBilliard
{
    public class Client
    {
        public string Name { get; set; }
        public Dictionary<string,int> Cart { get; set; }
    }

    class P07AndreyAndBilliard
    {
        static void Main(string[] args)
        {
            int productsAmount = int.Parse(Console.ReadLine());
            Dictionary<string, decimal> priceList = new Dictionary<string, decimal>();
            for (int i = 0; i < productsAmount; i++)
            {
                string[] currentProduct = Console.ReadLine().Split('-');
                string currentProductType = currentProduct[0];
                decimal currentProductPrice = decimal.Parse(currentProduct[1]);
                if (!priceList.ContainsKey(currentProductType))
                {
                    priceList.Add(currentProductType,currentProductPrice);
                }
                else
                {
                    priceList[currentProductType] = currentProductPrice;
                }
            }
            string clientInfo = Console.ReadLine();
            List<Client> orderList = new List<Client>();
            while (clientInfo!="end of clients")
            {
                string[] clientInfoDetails = clientInfo.Split(new[] {'-', ','});
                if (!priceList.ContainsKey(clientInfoDetails[1]))
                {
                    clientInfo = Console.ReadLine();
                    continue;
                }
                Client currentClient = new Client();
                currentClient.Cart = new Dictionary<string, int>();
                currentClient.Name = clientInfoDetails[0];
                currentClient.Cart.Add(clientInfoDetails[1], int.Parse(clientInfoDetails[2]));
                if (!orderList.Any(p => p.Name == clientInfoDetails[0]))
                {
                    orderList.Add(currentClient);
                    clientInfo = Console.ReadLine();
                    continue;;
                }
                foreach (var client in orderList)
                {
                    if (client.Name==currentClient.Name)
                    {
                        if (!client.Cart.ContainsKey(clientInfoDetails[1]))
                        {
                            client.Cart.Add(clientInfoDetails[1], int.Parse(clientInfoDetails[2]));
                        }
                        else
                        {
                            client.Cart[clientInfoDetails[1]] += int.Parse(clientInfoDetails[2]);
                        }
                    }
                }
                clientInfo = Console.ReadLine();
            }
            decimal totalBill = 0;
            foreach (var client in orderList.OrderBy(n => n.Name))
            {
                Console.WriteLine(client.Name);
                decimal bill = 0;
                foreach (var item in client.Cart)
                {
                    Console.WriteLine($"-- {item.Key} - {item.Value}");
                    bill += item.Value * priceList[item.Key];
                }
                totalBill += bill;
                Console.WriteLine($"Bill: {bill:f2}");
            }
            Console.WriteLine($"Total bill: {totalBill:f2}");
        }
    }
}
