using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P07AdvertisementMessage
{
    class P07AdvertisementMessage
    {
        static void Main(string[] args)
        {
            string inputFilePath = "../../input.txt";
            string outputFilePath = "../../output.txt";
            File.WriteAllText(outputFilePath, String.Empty);
            string input = File.ReadAllText(inputFilePath);
            string[] phrases =
            {
                "Excellent product.", "Such a great product.", "I always use that product.",
                "Best product of its category.", "Exceptional product.", "I can’t live without this product."
            };
            string[] events =
            {
                "Now I feel good.", "I have succeeded with this product.", "Makes miracles. I am happy of the results!",
                "I cannot believe but now I feel awesome.", "Try it yourself, I am very satisfied.", "I feel great!"
            };
            string[] authors =
            {
                "Now I feel good.", "I have succeeded with this product.", "Makes miracles. I am happy of the results!",
                "I cannot believe but now I feel awesome.", "Try it yourself, I am very satisfied.", "I feel great!"
            };
            string[] cities = { "Burgas", "Sofia", "Plovdiv", "Varna", "Ruse" };
            Random rndNum = new Random();
            int n = int.Parse(input);
            int phrasesIndex = 0;
            int eventsIndex = 0;
            int authorsIndex = 0;
            int citiesIndex = 0;
            for (int i = 0; i < n; i++)
            {
                phrasesIndex = rndNum.Next(0, phrases.Length - 1);
                eventsIndex = rndNum.Next(0, events.Length - 1);
                authorsIndex = rndNum.Next(0, authors.Length - 1);
                citiesIndex = rndNum.Next(0, cities.Length - 1);
                File.AppendAllText(outputFilePath, $"{phrases[phrasesIndex]} {events[eventsIndex]} {authors[authorsIndex]} - {cities[citiesIndex]}.");
                File.AppendAllText(outputFilePath, Environment.NewLine);
            }
        }
    }
}
