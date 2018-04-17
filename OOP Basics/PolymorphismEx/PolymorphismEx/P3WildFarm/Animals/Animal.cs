using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public abstract class Animal
{
    protected double WeightIncreasePerUnitOfFood { get; set; }

    protected virtual string[] EatableFoods { get; }

    protected string Name { get; set; }

    protected double Weight { get; set; }

    protected int FoodEaten { get; set; }

    protected Animal(string name, double weight)
    {
        this.Name = name;
        this.Weight = weight;
    }

    public abstract string ProduceSound();

    public virtual void Feed(Food food)
    {
        if (this.EatableFoods.Contains(food.GetType().Name))
        {
            this.FoodEaten += food.Quantity;
            this.Weight += WeightIncreasePerUnitOfFood * food.Quantity;
        }
        else
        {
            throw new ArgumentException($"{this.GetType().Name} does not eat {food}!");
        }
    }
}

