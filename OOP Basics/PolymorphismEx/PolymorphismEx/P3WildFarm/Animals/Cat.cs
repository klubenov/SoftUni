using System;
using System.Collections.Generic;
using System.Text;


public class Cat : Feline
{
    protected override string[] EatableFoods { get; }

    public Cat(string name, double weight, string livingRegion, string breed) : base(name, weight, livingRegion, breed)
    {
        this.EatableFoods = new string[] { "Meat", "Vegetable" };
        this.WeightIncreasePerUnitOfFood = 0.3;
    }

    public override string ProduceSound()
    {

        return "Meow";
    }
}

