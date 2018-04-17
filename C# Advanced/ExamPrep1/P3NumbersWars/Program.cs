using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace P3NumbersWars
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] firstPlayerInput = Console.ReadLine().Split(' ');
            string[] secondPlayerInput = Console.ReadLine().Split(' ');

            Queue<KeyValuePair<int,char>> firstPlayerQueue = new Queue<KeyValuePair<int, char>>();
            Queue<KeyValuePair<int, char>> secondPlayerQueue = new Queue<KeyValuePair<int, char>>();

            foreach (var card in firstPlayerInput)
            {
                KeyValuePair<int, char> currentCard = new KeyValuePair<int, char>(int.Parse(card.Substring(0,card.Length-1)),card[card.Length-1]);
                firstPlayerQueue.Enqueue(currentCard);
            }
            foreach (var card in secondPlayerInput)
            {
                KeyValuePair<int, char> currentCard = new KeyValuePair<int, char>(int.Parse(card.Substring(0, card.Length - 1)), card[card.Length - 1]);
                secondPlayerQueue.Enqueue(currentCard);
            }

            for (int i = 1; i <= 1000000; i++)
            {
                List<KeyValuePair<int, char>> tableDraw = new List<KeyValuePair<int, char>>();
                KeyValuePair<int, char> firstPlayerDefDraw = firstPlayerQueue.Dequeue();
                KeyValuePair<int, char> secondPlayerDefDraw = secondPlayerQueue.Dequeue();
                tableDraw.Add(firstPlayerDefDraw);
                tableDraw.Add(secondPlayerDefDraw);
                if (firstPlayerDefDraw.Key > secondPlayerDefDraw.Key)
                {
                    firstPlayerQueue.Enqueue(firstPlayerDefDraw);
                    firstPlayerQueue.Enqueue(secondPlayerDefDraw);
                    //AddTableToWinner(firstPlayerQueue, tableDraw);
                }
                else if (firstPlayerDefDraw.Key < secondPlayerDefDraw.Key)
                {
                    secondPlayerQueue.Enqueue(secondPlayerDefDraw);
                    secondPlayerQueue.Enqueue(firstPlayerDefDraw);
                    //AddTableToWinner(secondPlayerQueue, tableDraw);
                }
                else
                {
                    bool firstPlayerOutOfCards = false;
                    bool thereIsWinnerOfRound = false;
                    while (!thereIsWinnerOfRound)
                    {
                        int firstPlayerWarSum = 0;
                        int secondPlayerWarSum = 0;
                        for (int j = 0; j < 3; j++)
                        {
                            try
                            {
                                var currentCard = firstPlayerQueue.Dequeue();
                                firstPlayerWarSum += (int)currentCard.Value;
                                tableDraw.Add(currentCard);
                            }
                            catch (InvalidOperationException)
                            {
                                firstPlayerOutOfCards = true;
                            }

                            try
                            {
                                var currentCard = secondPlayerQueue.Dequeue();
                                secondPlayerWarSum += (int)currentCard.Value;
                                tableDraw.Add(currentCard);
                            }
                            catch (InvalidOperationException)
                            {
                                if (firstPlayerOutOfCards)
                                {
                                    Console.WriteLine($"Draw after {i} turns");
                                    Environment.Exit(0);
                                }
                                Console.WriteLine($"First player wins after {i} turns");
                                Environment.Exit(0);
                            }
                            if (firstPlayerOutOfCards)
                            {
                                Console.WriteLine($"Second player wins after {i} turns");
                            }
                        }

                        if (firstPlayerWarSum > secondPlayerWarSum)
                        {
                            thereIsWinnerOfRound = true;
                            AddTableToWinner(firstPlayerQueue, tableDraw);
                            tableDraw.Clear();
                        }
                        else if (secondPlayerWarSum > firstPlayerWarSum)
                        {
                            thereIsWinnerOfRound = true;
                            AddTableToWinner(secondPlayerQueue, tableDraw);
                            tableDraw.Clear();
                        }
                    }
                }
                CheckForZeroCardsInEitherHand(firstPlayerQueue, secondPlayerQueue, i);
            }
            int firstPlayerCount = firstPlayerQueue.Count;
            int secondPlayerCount = secondPlayerQueue.Count;
            if (firstPlayerCount>secondPlayerCount)
            {
                Console.WriteLine("First player wins after 1000000 turns");
            }
            else if (secondPlayerCount > firstPlayerCount)
            {
                Console.WriteLine("Second player wins after 1000000 turns");
            }
            else
            {
                Console.WriteLine("Draw after 1000000 turns");
            }
        }

        private static void CheckForZeroCardsInEitherHand(Queue<KeyValuePair<int, char>> firstPlayerQueue, Queue<KeyValuePair<int, char>> secondPlayerQueue, int i)
        {
            if (firstPlayerQueue.Count == 0)
            {   
                Console.WriteLine($"Second player wins after {i} turns");
                Environment.Exit(0);
            }
            else if (secondPlayerQueue.Count == 0)
            {
                Console.WriteLine($"First player wins after {i} turns");
                Environment.Exit(0);
            }
        }

        private static void AddTableToWinner(Queue<KeyValuePair<int, char>> PlayerQueue, List<KeyValuePair<int, char>> tableDraw)
        {
            KeyValuePair<int, char>[] orderedTalbeDraw = new KeyValuePair<int, char>[tableDraw.Count];
            if (tableDraw.Count > 2)
            {
                orderedTalbeDraw = tableDraw.OrderByDescending(x => x.Key).ThenByDescending(x => x.Value).ToArray();
            }
            else
            {
                orderedTalbeDraw = tableDraw.OrderByDescending(x => x.Key).ToArray();
            }
            foreach (var card in orderedTalbeDraw)
            {
                PlayerQueue.Enqueue(card);
            }
        }
    }
}
