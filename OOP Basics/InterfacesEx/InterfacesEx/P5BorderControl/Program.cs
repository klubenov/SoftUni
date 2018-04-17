using System;
using System.Collections.Generic;
using System.Linq;


public class Program
{
    static void Main(string[] args)
    {
        int entityCount = int.Parse(Console.ReadLine());

        var entityArray = new IBuyer[entityCount];

        for (int i = 0; i < entityCount; i++)
        {
            var entityData = Console.ReadLine().Split(' ');

            if (entityData.Length==3)
            {
                var newRebel = new Rebel(entityData[0], int.Parse(entityData[1]), entityData[2]);
                entityArray[i] = newRebel;
            }
            else
            {
                var newCitizen = new Citizen(entityData[0], int.Parse(entityData[1]), entityData[2], entityData[3]);
                entityArray[i] = newCitizen;
            }
        }

        string buyer;

        while ((buyer=Console.ReadLine())!="End")
        {
            try
            {
                entityArray.First(e => e.Name == buyer).BuyFood();
            }
            catch (Exception)
            {
            }
        }

        Console.WriteLine(entityArray.Sum(e=>e.Food));
    }
}

