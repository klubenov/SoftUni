using System;
using System.Collections.Generic;
using System.Text;


class Trainer
{
    public string Name { get; set; }

    public int BadgeCount { get; set; }

    public List<Pokemon> PokemonCollectionList { get; set; }

    public int Position { get; set; }

    public Trainer(string name, int position)
    {
        Name = name;
        Position = position;
        BadgeCount = 0;
        PokemonCollectionList=new List<Pokemon>();
    }
}

