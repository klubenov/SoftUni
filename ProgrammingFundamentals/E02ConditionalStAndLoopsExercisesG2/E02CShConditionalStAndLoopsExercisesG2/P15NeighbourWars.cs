using System;

namespace P15NeighbourWars
{
    class P15NeighbourWars
    {
        static void Main(string[] args)
        {
            var peshoDmg = int.Parse(Console.ReadLine());
            var goshoDmg = int.Parse(Console.ReadLine());
            var peshoHlt = 100;
            var goshoHlt = 100;
            var roundCount = 0;
            for (int i = 1; i < Int32.MaxValue; i++)
            {
                roundCount++;
                if ((i + 2) % 2 == 1)
                {
                    goshoHlt = goshoHlt - peshoDmg;
                    if (goshoHlt <= 0)
                    {
                        Console.WriteLine($"Pesho won in {roundCount}th round.");
                        break;
                    }
                    Console.WriteLine($"Pesho used Roundhouse kick and reduced Gosho to {goshoHlt} health.");
                }
                else
                {
                    peshoHlt = peshoHlt - goshoDmg;
                    if (peshoHlt <= 0)
                    {
                        Console.WriteLine($"Gosho won in {roundCount}th round.");
                        break;
                    }
                    Console.WriteLine($"Gosho used Thunderous fist and reduced Pesho to {peshoHlt} health.");
                }
                if ((i + 3) % 3 == 0)
                {
                    peshoHlt += 10;
                    goshoHlt += 10;
                }
            }
        }
    }
}
