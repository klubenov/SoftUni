using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P09LegendaryFarming
{
    class P09LegendaryFarming
    {
        static void PrintItemAndMaterials(Dictionary<string, int> legItems, SortedDictionary<string, int> junkItems, string mat250)
        {
            switch (mat250)
            {
                case "motes":
                    Console.WriteLine("Dragonwrath obtained!");
                    break;
                case "shards":
                    Console.WriteLine("Shadowmourne obtained!");
                    break;
                case "fragments":
                    Console.WriteLine("Valanyr obtained!");
                    break;
            }
            legItems[mat250] -= 250;
            foreach (var item in legItems.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {

                Console.WriteLine($"{item.Key}: {item.Value}");
            }
            foreach (var item in junkItems)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }

        }

        static void Main(string[] args)
        {
            string input = Console.ReadLine().ToLower();
            Dictionary<string, int> legItems = new Dictionary<string, int>();
            legItems.Add("shards", 0);
            legItems.Add("motes", 0);
            legItems.Add("fragments", 0);
            SortedDictionary<string,int> junkItems = new SortedDictionary<string, int>();
            while (true)
            {
                string[] materials = input.Split(' ');
                for (int i = 1; i < materials.Length; i=i+2)
                {
                    if (materials[i] != "motes" && materials[i] != "fragments" && materials[i] != "shards")
                    {
                        if (junkItems.ContainsKey(materials[i]))
                        {
                            junkItems[materials[i]] += int.Parse(materials[i - 1]);
                        }
                        else
                        {
                            junkItems.Add(materials[i], int.Parse(materials[i - 1]));
                        }
                    }
                    switch (materials[i])
                    {
                        case "motes":
                            legItems[materials[i]] += int.Parse(materials[i - 1]);
                            break;
                        case "shards":
                            legItems[materials[i]] += int.Parse(materials[i - 1]);
                            break;
                        case "fragments":
                            legItems[materials[i]] += int.Parse(materials[i - 1]);
                            break;
                    }
                    foreach (var item in legItems)
                    {
                        if (item.Value >= 250)
                        {
                            PrintItemAndMaterials(legItems,junkItems,item.Key);
                            return;
                        }
                    }
                }
                input = Console.ReadLine().ToLower();
            }
        }
    }
}
