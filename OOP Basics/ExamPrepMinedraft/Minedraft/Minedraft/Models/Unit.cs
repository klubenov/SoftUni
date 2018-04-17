using System;
using System.Collections.Generic;
using System.Text;


public abstract class Unit
{
    public string Id { get; protected set; }

    public string Type { get; protected set; }

    protected Unit(string id)
    {
        Id = id;
    }
}

