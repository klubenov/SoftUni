using System;
using System.Collections.Generic;
using System.Text;


public abstract class Bird : Animal
{
    protected double WingSize { get; set; }

    protected Bird(string name, double weight, double wingSize) : base(name, weight)
    {
        this.WingSize = wingSize;
    }

    public override string ToString()
    {
        return $"{this.GetType().Name} [{this.Name}, {this.WingSize}, {this.Weight}, {this.FoodEaten}]";
    }
}
