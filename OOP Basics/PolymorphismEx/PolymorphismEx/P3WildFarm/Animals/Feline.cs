﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public abstract class Feline : Mammal
{
    protected string Breed { get; set; }

    protected Feline(string name, double weight, string livingRegion, string breed) : base(name, weight, livingRegion)
    {
        this.Breed = breed;
    }

    public override string ToString()
    {
        return $"{this.GetType().Name} [{this.Name}, {this.Breed}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
    }
}
