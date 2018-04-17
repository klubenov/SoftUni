using System;


class Program
{
    static void Main(string[] args)
    {
        int personCount = int.Parse(Console.ReadLine());
        var family = new Family();

        for (int i = 0; i < personCount; i++)
        {
            var personData = Console.ReadLine().Split(' ');
            family.AddMember(new Person { Name = personData[0], Age = int.Parse(personData[1]) });
        }

        var olderThan30 = family.OlderThan30List();
        foreach (var person in olderThan30)
        {
            Console.WriteLine($"{person.Name} - {person.Age}");
        }
    }
}

