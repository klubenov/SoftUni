using System;
using System.Collections.Generic;
using System.Linq;

namespace KeyRevolver
{
    class Program
    {
        static void Main(string[] args)
        {
            int bulletPrice = int.Parse(Console.ReadLine());
            int barrelSize = int.Parse(Console.ReadLine());
            Stack<int> bulletsStack = new Stack<int>(Console.ReadLine().Split(' ').Select(int.Parse));
            int initialBulletCount = bulletsStack.Count;
            Queue<int> lockQueue = new Queue<int>(Console.ReadLine().Split(' ').Select(int.Parse));
            int dataValue = int.Parse(Console.ReadLine());

            int tempBarrel = 0;

            while (bulletsStack.Count>0)
            {
                if (tempBarrel==barrelSize)
                {
                    Console.WriteLine("Reloading!");
                    tempBarrel = 0;
                    continue;
                }

                int bullet = bulletsStack.Pop();
                tempBarrel++;

                if (bullet<=lockQueue.Peek())
                {
                    lockQueue.Dequeue();
                    Console.WriteLine("Bang!");
                }
                else
                {
                    Console.WriteLine("Ping!");
                }

                if (lockQueue.Count==0)
                {
                    if (tempBarrel == barrelSize && bulletsStack.Count!=0)
                    {
                        Console.WriteLine("Reloading!");
                    }

                    int bulletCost = (initialBulletCount - bulletsStack.Count) * bulletPrice;
                    int earnings = dataValue - bulletCost;

                    Console.WriteLine($"{bulletsStack.Count} bullets left. Earned ${earnings}");
                    Environment.Exit(0);
                }
            }

            Console.WriteLine($"Couldn't get through. Locks left: {lockQueue.Count}");
        }
    }
}
