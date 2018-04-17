using System;
using System.Collections.Generic;
using System.Linq;


class P12Google
{
    static void Main(string[] args)
    {
        string input;

        var personDict = new Dictionary<string,Person>();

        while ((input=Console.ReadLine())!="End")
        {
            var inputData = input.Split(' ');

            string personName = inputData[0];
            string inputType = inputData[1];

            if (!personDict.Keys.Contains(personName))
            {
                var newPerson = new Person(personName);
                personDict.Add(personName,newPerson);
            }

            switch (inputType)
            {
                case "company":
                    personDict[personName].Company.Name = inputData[2];
                    personDict[personName].Company.Department = inputData[3];
                    personDict[personName].Company.Salary = decimal.Parse(inputData[4]);
                    break;
                case "car":
                    personDict[personName].Car.Model = inputData[2];
                    personDict[personName].Car.Speed = int.Parse(inputData[3]);
                    break;
                case "pokemon":
                    var newPokemon = new Pokemon(inputData[2], inputData[3]);
                    personDict[personName].Pokemons.Add(newPokemon);
                    break;
                case "parents":
                    var newParent = new Parent(inputData[2], inputData[3]);
                    personDict[personName].Parents.Add(newParent);
                    break;
                case "children":
                    var newChild = new Child(inputData[2], inputData[3]);
                    personDict[personName].Children.Add(newChild);
                    break;
            }            
        }

        string personToBePrinted = Console.ReadLine();

        Console.WriteLine(personDict[personToBePrinted]);
    }
}

