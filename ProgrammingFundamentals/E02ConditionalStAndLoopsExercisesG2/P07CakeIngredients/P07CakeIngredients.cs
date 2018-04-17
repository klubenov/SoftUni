using System;

namespace P07CakeIngredients
{
    class P07CakeIngredients
    {
        static void Main(string[] args)
        {
            var ingrCount = 0;
            for (int i = 0; i < Int32.MaxValue; i++)
            {
                string currIngredient = Console.ReadLine();
                if (currIngredient == "Bake!")
                {
                    Console.WriteLine($"Preparing cake with {ingrCount} ingredients.");
                    break;
                }
                else Console.WriteLine($"Adding ingredient {currIngredient}.");
                ingrCount++;
            }
        }
    }
}
