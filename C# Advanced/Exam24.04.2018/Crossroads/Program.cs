using System;
using System.Collections.Generic;

namespace Crossroads
{
    class Program
    {
        static void Main(string[] args)
        {
            int greenLightDuration = int.Parse(Console.ReadLine());
            int freeWindow = int.Parse(Console.ReadLine());
            var currentCars = new Queue<char>();
            var carLenghts = new List<string>();
            int carsPassed = 0;

            while (true)
            {
                string input = Console.ReadLine();

                if (input=="END")
                {
                    break;
                }

                currentCars.Clear();
                carLenghts.Clear();
                
                
                while (true)
                {
                    if (input=="green")
                    {
                        break;
                    }

                    AddCarsToQueue(input, currentCars);
                    carLenghts.Add(input);
                    input = Console.ReadLine();

                    if (input == "green")
                    {
                        break;
                    }
                }

                bool carsRemainAfterGreenLight = true;
                int currentCarLength = 0;


                for (int i = 0; i < greenLightDuration; i++)
                {
                    try
                    {
                        currentCars.Dequeue();
                        currentCarLength++;
                        if (carLenghts.Count>0)
                        {
                            if (currentCarLength == carLenghts[0].Length)
                            {
                                currentCarLength = 0;
                                carsPassed++;
                                carLenghts.RemoveAt(0);
                            }
                        }

                    }
                    catch
                    {
                        carsPassed += carLenghts.Count;
                        carsRemainAfterGreenLight = false;
                        break;
                    }
                }
                if (carsRemainAfterGreenLight)
                {
                    if (currentCarLength != 0 && carLenghts[0].Length - currentCarLength > freeWindow)
                    {
                        try
                        {
                            for (int i = 0; i < freeWindow; i++)
                            {
                                currentCars.Dequeue();
                            }
                        }
                        catch
                        {
                        }
                        

                        Console.WriteLine("A crash happened!");
                        Console.WriteLine($"{carLenghts[0]} was hit at {currentCars.Peek()}.");
                        Environment.Exit(0);
                    }
                    else if (currentCarLength != 0)
                    {
                        carsPassed++;
                    }
                }

                //if (currentCars.Count!=0)
                //{
                //    int totalTimeInTheCrossroad = greenLightDuration + freeWindow;
                //    int lenghtChecker = 0;
                //    string crashedCar = "";
                //    foreach (var car in carLenghts)
                //    {
                //        lenghtChecker += car.Length;
                //        if (lenghtChecker>totalTimeInTheCrossroad)
                //        {
                //            crashedCar = car;
                //            break;
                //        }
                //    }

                //    Console.WriteLine("A crash happened!");
                //    Console.WriteLine($"{crashedCar} was hit at {currentCars.Peek()}.");
                //    Environment.Exit(0);
                //}     
            }

            Console.WriteLine("Everyone is safe.");
            Console.WriteLine($"{carsPassed} total cars passed the crossroads.");
        }

        public static void AddCarsToQueue(string car, Queue<char> carQueue)
        {
            foreach (var character in car)
            {
                carQueue.Enqueue(character);
            }
        }
    }
}
