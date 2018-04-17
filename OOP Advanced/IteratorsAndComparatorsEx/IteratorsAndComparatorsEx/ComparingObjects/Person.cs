using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class Person:IComparable<Person>
{
    public string Name { get; }

    public int Age { get; }

    //public string Town { get; }

    public Person(string name, int age)
    {
        this.Name = name;
        this.Age = age;
    }

    public override string ToString()
    {
        return $"{this.Name} {this.Age}";
    }

    public int CompareTo(Person other)
    {
        var result = this.Name.CompareTo(other.Name);
        if (result == 0)
        {
            result = this.Age - other.Age;
        }

        return result;
    }

    public override bool Equals(object other)
    {
        var otherPerson = other as Person;
        bool equality = this.Name == otherPerson.Name && this.Age == otherPerson.Age;
        return equality;
    }

    public override int GetHashCode()
    {
        var nameHasg = this.Name.ToCharArray().Select(i => (int)i).Sum();
        return nameHasg + Age;
    }
}

