using System;
using System.Collections.Generic;
using System.Text;

public class Hen : Bird
{
    public Hen(string name, double weight, double wingSize) : base(name, weight, wingSize)
    {
        this.EatableFoods = new string[] { "Fruit", "Meat", "Seeds", "Vegetable" };
        this.WeightIncreasePerUnitOfFood = 0.35;
    }

    public override string ProduceSound()
    {
        return "Cluck";
    }

    protected override string[] EatableFoods { get; }
}

