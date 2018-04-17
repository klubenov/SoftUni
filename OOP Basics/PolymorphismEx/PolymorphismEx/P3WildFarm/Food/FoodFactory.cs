using System;
using System.Collections.Generic;
using System.Text;


public static class FoodFactory
{
    public static Food Instantiate(string food)
    {
        var foodData = food.Split(' ');

        if (foodData[0]=="Fruit")
        {
            var newFruit = new Fruit(int.Parse(foodData[1]));
            return newFruit;
        }
        else if (foodData[0] == "Meat")
        {
            var newMeat = new Meat(int.Parse(foodData[1]));
            return newMeat;
        }
        else if (foodData[0] == "Seeds")
        {
            var newSeeds = new Seeds(int.Parse(foodData[1]));
            return newSeeds;
        }
        else
        {
            var newVegetable = new Vegetable(int.Parse(foodData[1]));
            return newVegetable;
        }
    }
}

