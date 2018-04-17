using System;
using System.Collections.Generic;

namespace ComparingObjects
{
    class Program
    {
        static void Main(string[] args)
        {
            var peopleSortedSet = new SortedSet<Person>();
            var peopleHashSet = new SortedSet<Person>();

            int peopleCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < peopleCount; i++)
            {
                var personData = Console.ReadLine().Split(' ');
                var newPerson = new Person(personData[0], int.Parse(personData[1]));
                peopleSortedSet.Add(newPerson);
                peopleHashSet.Add(newPerson);
            }

            Console.WriteLine(peopleSortedSet.Count);
            Console.WriteLine(peopleHashSet.Count);
        }
    }
}
