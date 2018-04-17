using System;
using System.Collections.Generic;
using System.Text;

public class Dog : Mammal
{
    public Dog(string name, double weight, string livingRegion) : base(name, weight, livingRegion)
    {
        this.EatableFoods = new string[]{"Meat"};
        this.WeightIncreasePerUnitOfFood = 0.4;
    }

    public override string ProduceSound()
    {
        return "Woof!";
    }

    protected override string[] EatableFoods { get; }
}
