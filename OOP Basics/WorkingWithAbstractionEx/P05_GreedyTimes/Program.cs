using System;
using System.Collections.Generic;
using System.Linq;

namespace P05_GreedyTimes
{

    public class Potato
    {
        static void Main(string[] args)
        {
            long bagCapacity = long.Parse(Console.ReadLine());
            string[] safeContents = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var thiefBag = new Dictionary<string, Dictionary<string, long>>();
            long currentGoldAmountInBag = 0;
            long currentGemAmountInBag = 0;
            long currentCashAmountInBag = 0;

            for (int i = 0; i < safeContents.Length; i += 2)
            {
                string currentContentName = safeContents[i];
                long currentContentCount = long.Parse(safeContents[i + 1]);

                string currentContentType = "";

                if (currentContentName.Length == 3)
                {
                    currentContentType = "Cash";
                }
                else if (currentContentName.ToLower().EndsWith("gem"))
                {
                    currentContentType = "Gem";
                }
                else if (currentContentName.ToLower() == "gold")
                {
                    currentContentType = "Gold";
                }

                if (currentContentType == "")
                {
                    continue;
                }
                else if (bagCapacity < thiefBag.Values.Select(x => x.Values.Sum()).Sum() + currentContentCount)
                {
                    continue;
                }

                switch (currentContentType)
                {
                    case "Gem":
                        if (!thiefBag.ContainsKey(currentContentType))
                        {
                            if (thiefBag.ContainsKey("Gold"))
                            {
                                if (currentContentCount > thiefBag["Gold"].Values.Sum())
                                {
                                    continue;
                                }
                            }
                            else
                            {
                                continue;
                            }
                        }
                        else if (thiefBag[currentContentType].Values.Sum() + currentContentCount > thiefBag["Gold"].Values.Sum())
                        {
                            continue;
                        }
                        break;
                    case "Cash":
                        if (!thiefBag.ContainsKey(currentContentType))
                        {
                            if (thiefBag.ContainsKey("Gem"))
                            {
                                if (currentContentCount > thiefBag["Gem"].Values.Sum())
                                {
                                    continue;
                                }
                            }
                            else
                            {
                                continue;
                            }
                        }
                        else if (thiefBag[currentContentType].Values.Sum() + currentContentCount > thiefBag["Gem"].Values.Sum())
                        {
                            continue;
                        }
                        break;
                }

                if (!thiefBag.ContainsKey(currentContentType))
                {
                    thiefBag[currentContentType] = new Dictionary<string, long>();
                }

                if (!thiefBag[currentContentType].ContainsKey(currentContentName))
                {
                    thiefBag[currentContentType][currentContentName] = 0;
                }

                thiefBag[currentContentType][currentContentName] += currentContentCount;
                if (currentContentType == "Gold")
                {
                    currentGoldAmountInBag += currentContentCount;
                }
                else if (currentContentType == "Gem")
                {
                    currentGemAmountInBag += currentContentCount;
                }
                else if (currentContentType == "Cash")
                {
                    currentCashAmountInBag += currentContentCount;
                }
            }

            foreach (var contentType in thiefBag)
            {
                Console.WriteLine($"<{contentType.Key}> ${contentType.Value.Values.Sum()}");
                foreach (var item2 in contentType.Value.OrderByDescending(y => y.Key).ThenBy(y => y.Value))
                {
                    Console.WriteLine($"##{item2.Key} - {item2.Value}");
                }
            }
        }
    }
}