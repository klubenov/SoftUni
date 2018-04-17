using System;
using System.Collections.Generic;
using System.Text;


public class Tiger : Feline
{
    protected override string[] EatableFoods { get; }

    public Tiger(string name, double weight, string livingRegion, string breed) : base(name, weight, livingRegion, breed)
    {
        this.EatableFoods = new string[] { "Meat" };
        this.WeightIncreasePerUnitOfFood = 1.0;
    }

    public override string ProduceSound()
    {

        return "ROAR!!!";
    }
}

