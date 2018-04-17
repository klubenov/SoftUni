using System;
using System.Collections.Generic;
using System.Text;


class Person
{
    public string Name { get; set; }

    public Company Company { get; set; }

    public Car Car { get; set; }

    public List<Pokemon> Pokemons { get; set; }

    public List<Child> Children { get; set; }

    public List<Parent> Parents { get; set; }

    public Person(string name)
    {
        Name = name;
        Company=new Company();
        Car=new Car();
        Pokemons=new List<Pokemon>();
        Children=new List<Child>();
        Parents=new List<Parent>();
    }

    public override string ToString()
    {
        var printStringBuilder = new StringBuilder();

        printStringBuilder.Append(Name).AppendLine();

        printStringBuilder.Append("Company:").AppendLine().Append(Company);

        printStringBuilder.Append("Car:").AppendLine().Append(Car);

        printStringBuilder.Append("Pokemon:").AppendLine();
        foreach (var pokemon in Pokemons)
        {
            printStringBuilder.Append(pokemon).AppendLine();
        }

        printStringBuilder.Append("Parents:").AppendLine();
        foreach (var parent in Parents)
        {
            printStringBuilder.Append(parent).AppendLine();
        }

        printStringBuilder.Append("Children:").AppendLine();
        foreach (var child in Children)
        {
            printStringBuilder.Append(child).AppendLine();
        }

        return printStringBuilder.ToString();
    }
}

