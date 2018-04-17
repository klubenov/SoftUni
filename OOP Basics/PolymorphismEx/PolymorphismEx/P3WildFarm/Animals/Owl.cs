using System;
using System.Collections.Generic;
using System.Text;

public class Owl : Bird
{
    public Owl(string name, double weight, double wingSize) : base(name, weight, wingSize)
    {
        this.EatableFoods = new string[] { "Meat" };
        this.WeightIncreasePerUnitOfFood = 0.25;
    }

    public override string ProduceSound()
    {
        return "Hoot Hoot";
    }

    protected override string[] EatableFoods { get; }
}

