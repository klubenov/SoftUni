using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;


class Person
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

    private decimal money;

    public decimal Money
    {
        get { return this.money; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Money cannot be negative");
            }
            money = value;
        }
    }

    public List<Product> BagList { get; set; }

    public Person(string name, decimal money)
    {
        Name = name;
        Money = money;
        BagList = new List<Product>();
    }

    public override string ToString()
    {
        if (BagList.Count==0)
        {
            return $"{name} - Nothing bought";
        }
        var bagListContents = new StringBuilder();
        for (int i = 0; i < BagList.Count; i++)
        {
            bagListContents.Append(BagList[i]);
            if (i!=BagList.Count-1)
            {
                bagListContents.Append(", ");
            }
        }
        return $"{name} - {bagListContents}";
    }
}

