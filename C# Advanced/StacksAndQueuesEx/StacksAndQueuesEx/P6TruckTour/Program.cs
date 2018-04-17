using System;
using System.Collections.Generic;

namespace P6TruckTour
{
    class Program
    {
        static void Main(string[] args)
        {
            int pumpCount = int.Parse(Console.ReadLine());

            var pumpQueue = new Queue<Tuple<long, long>>();


            for (int i = 0; i < pumpCount; i++)
            {
                var pumpParams = Console.ReadLine().Split(' ');
                var petrolAmount = long.Parse(pumpParams[0]);
                var distanceToNextPump = long.Parse(pumpParams[1]);
                Tuple<long, long> currentPumpTuple = new Tuple<long, long>(petrolAmount,distanceToNextPump);
                pumpQueue.Enqueue(currentPumpTuple);
            }

            for (int i = 0; i < pumpCount; i++)
            {
                if(i!=0)
                {
                    var rotationStack = pumpQueue.Dequeue();
                    pumpQueue.Enqueue(rotationStack);
                }

                var iterationArr = pumpQueue.ToArray();
                long currentPetrolAmount = 0;

                for (int j = 0; j < pumpCount; j++)
                {
                    var currentPump = iterationArr[j];
                    var distanceToNext = currentPump.Item2;
                    var petrolAmount = currentPump.Item1;
                    currentPetrolAmount += petrolAmount;

                    if (currentPetrolAmount < distanceToNext)
                    {
                        break;
                    }

                    if (j == pumpCount - 1)
                    {
                        Console.WriteLine(i);
                        return;
                    }
                    currentPetrolAmount -= distanceToNext;
                }
            }
        }
    }
}
