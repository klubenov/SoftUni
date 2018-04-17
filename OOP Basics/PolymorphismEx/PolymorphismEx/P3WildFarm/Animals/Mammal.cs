using System;
using System.Collections.Generic;
using System.Text;


public abstract class Mammal : Animal
{
    protected string LivingRegion { get; set; }

    protected Mammal(string name, double weight, string livingRegion) : base(name, weight)
    {
        this.LivingRegion = livingRegion;
    }

    public override string ToString()
    {
        return $"{this.GetType().Name} [{this.Name}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
    }
}

