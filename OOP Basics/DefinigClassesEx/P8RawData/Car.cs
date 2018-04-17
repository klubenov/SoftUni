using System;
using System.Collections.Generic;
using System.Text;


class Car
{
    public string Name { get; set; }

    public Engine Engine { get; set; }

    public Cargo Cargo { get; set; }

    public Tyre[] Tyres { get; set; }

    public Car(string name, Engine engine, Cargo cargo, Tyre[] tyres)
    {
        Name = name;
        Engine = engine;
        Cargo = cargo;
        Tyres = tyres;
    }

}

