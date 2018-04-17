using System;
using System.Collections.Generic;
using System.Text;


class Product
{
    private string name;

    private string Name
    {
        get { return this.name; }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Name cannot be empty");
            }
            name = value;
        }
    }

    private decimal cost;

    public decimal Cost
    {
        get { return this.cost; }
        private set
        {
            if (value<0)
            {
                throw new ArgumentException("Money cannot be negative");
            }
            cost = value;
        }
    }

    public Product(string name, decimal cost)
    {
        Name = name;
        Cost = cost;
    }

    public override string ToString()
    {
        return $"{name}";
    }
}

