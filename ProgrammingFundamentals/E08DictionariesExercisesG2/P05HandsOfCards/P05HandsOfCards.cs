using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P05HandsOfCards
{
    class P05HandsOfCards
    {
        static int totalCardPoints(List<string> cards)
        {
            int sum = 0;
            int firstSymbol=0;
            int secondSymbol=0;
            foreach (string card in cards)
            {
                char[] points = card.ToCharArray();
                switch (points[0])
                {
                    case '1':
                        firstSymbol = 10;
                        break;
                    case '2':
                        firstSymbol = 2;
                        break;
                    case '3':
                        firstSymbol = 3;
                        break;
                    case '4':
                        firstSymbol = 4;
                        break;
                    case '5':
                        firstSymbol = 5;
                        break;
                    case '6':
                        firstSymbol = 6;
                        break;
                    case '7':
                        firstSymbol = 7;
                        break;
                    case '8':
                        firstSymbol = 8;
                        break;
                    case '9':
                        firstSymbol = 9;
                        break;
                    case 'J':
                        firstSymbol = 11;
                        break;
                    case 'Q':
                        firstSymbol = 12;
                        break;
                    case 'K':
                        firstSymbol = 13;
                        break;
                    case 'A':
                        firstSymbol = 14;
                        break;
                }
                switch (points[1])
                {
                    case 'S':
                        secondSymbol = 4;
                        break;
                    case 'H':
                        secondSymbol = 3;
                        break;
                    case 'D':
                        secondSymbol = 2;
                        break;
                    case 'C':
                        secondSymbol = 1;
                        break;
                    case '0':
                        switch (points[2])
                        {
                            case 'S':
                                secondSymbol = 4;
                                break;
                            case 'H':
                                secondSymbol = 3;
                                break;
                            case 'D':
                                secondSymbol = 2;
                                break;
                            case 'C':
                                secondSymbol = 1;
                                break;
                        }
                        break;
                }
                sum += firstSymbol * secondSymbol;
            }
            return sum;
        }

        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            var cardGame = new Dictionary<string,List<string>>();
            while (input != "JOKER")
            {
                string [] inputArr = input.Split(':').ToArray();
                string person = inputArr[0];
                List<string> cards = inputArr[1].Split(',').ToList();
                for (int i = 0; i < cards.Count; i++)
                {
                    cards[i] = cards[i].Trim();
                }
                if (!cardGame.ContainsKey(person))
                {
                    var diffCards = cards.Distinct().ToList();
                    cardGame.Add(person, diffCards);
                    
                }
                else
                {
                    foreach (string card in cards)
                    {
                        if(!cardGame[person].Contains(card))
                        cardGame[person].Add(card);
                    }
                }
                input = Console.ReadLine();
            }
            foreach (var player in cardGame)
            {
                Console.WriteLine($"{player.Key}: {totalCardPoints(player.Value)}");
            }
        }
    }
}
