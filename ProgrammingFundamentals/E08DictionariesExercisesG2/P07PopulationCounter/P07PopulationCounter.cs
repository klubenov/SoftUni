using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P07PopulationCounter
{
    class P07PopulationCounter
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, long>> popCounter = new Dictionary<string, Dictionary<string, long>>();
            string input = Console.ReadLine();
            while (input!="report")
            {
                string[] entries = input.Split('|');
                long pop = long.Parse(entries[2]);
                string country = entries[1];
                string city = entries[0];
                if (!popCounter.ContainsKey(entries[1]))
                {
                    popCounter.Add(country, new Dictionary<string, long>());
                    popCounter[country].Add(city,pop);
                }
                else
                {
                    popCounter[country].Add(city,pop);
                }
                input = Console.ReadLine();
            }
            foreach (var country in popCounter.OrderByDescending(x => x.Value.Values.Sum()))
            {
                Console.WriteLine($"{country.Key} (total population: {country.Value.Values.Sum()})");
                foreach (var city in country.Value.OrderByDescending(y => y.Value))
                {
                    
                    Console.WriteLine($"=>{city.Key}: {city.Value}");
                }
            }
        }
    }
}
