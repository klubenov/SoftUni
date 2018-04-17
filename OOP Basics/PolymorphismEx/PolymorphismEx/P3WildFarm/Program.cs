using System;
using System.Collections.Generic;


class Program
{
    static void Main(string[] args)
    {
        var animalList = new List<Animal>();

        string input;

        while ((input = Console.ReadLine()) != "End")
        {
            var animalData = input.Split(' ');

            switch (animalData[0])
            {
                case "Cat":
                    var newCat = new Cat(animalData[1], double.Parse(animalData[2]), animalData[3], animalData[4]);
                    AddAnimalAndFeedIt(newCat, animalList);
                    break;
                case "Tiger":
                    var newTiger = new Tiger(animalData[1], double.Parse(animalData[2]), animalData[3], animalData[4]);
                    AddAnimalAndFeedIt(newTiger, animalList);
                    break;
                case "Hen":
                    var newHen = new Hen(animalData[1], double.Parse(animalData[2]), double.Parse(animalData[3]));
                    AddAnimalAndFeedIt(newHen, animalList);
                    break;
                case "Owl":
                    var newOwl = new Owl(animalData[1], double.Parse(animalData[2]), double.Parse(animalData[3]));
                    AddAnimalAndFeedIt(newOwl, animalList);
                    break;
                case "Dog":
                    var newDog = new Dog(animalData[1], double.Parse(animalData[2]), animalData[3]);
                    AddAnimalAndFeedIt(newDog, animalList);
                    break;
                case "Mouse":
                    var newMouse = new Mouse(animalData[1], double.Parse(animalData[2]), animalData[3]);
                    AddAnimalAndFeedIt(newMouse, animalList);
                    break;
            }
        }

        foreach (var animal in animalList)
        {
            Console.WriteLine(animal);
        }
    }

    public static void AddAnimalAndFeedIt(Animal animal, List<Animal> animalList)
    {
        Console.WriteLine(animal.ProduceSound());
        animalList.Add(animal);
        try
        {
            var foodPortion = FoodFactory.Instantiate(Console.ReadLine());
            animal.Feed(foodPortion);
        }
        catch (ArgumentException exception)
        {
            Console.WriteLine(exception.Message);
        }
    }
}

