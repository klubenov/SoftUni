using System;

namespace CharacterStats
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            var curHealth = int.Parse(Console.ReadLine());
            var maxHealth = int.Parse(Console.ReadLine());
            var curEnergy = int.Parse(Console.ReadLine());
            var maxEnergy = int.Parse(Console.ReadLine());
            Console.WriteLine($"Name: {name}");
            Console.WriteLine("Health: |" + new string('|',curHealth) + new string('.', maxHealth - curHealth) + '|');
            Console.WriteLine("Energy: |" + new string('|',curEnergy) + new string('.', maxEnergy - curEnergy) + '|');
        }
    }
}
