using System;
using System.Collections.Generic;
using System.Text;


public class Mouse : Mammal
{
    public Mouse(string name, double weight, string livingRegion) : base(name, weight, livingRegion)
    {
        this.EatableFoods = new string[] { "Fruit", "Vegetable" };
        this.WeightIncreasePerUnitOfFood = 0.1;
    }

    public override string ProduceSound()
    {
        return "Squeak";
    }

    protected override string[] EatableFoods { get; }
}

