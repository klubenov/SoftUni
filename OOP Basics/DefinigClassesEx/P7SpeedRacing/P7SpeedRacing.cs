using System;
using System.Collections.Generic;
using System.Linq;


class P7SpeedRacing
{
    static void Main(string[] args)
    {
        int numberOfCars = int.Parse(Console.ReadLine());

        var carList = new List<Car>(numberOfCars);

        for (int i = 0; i < numberOfCars; i++)
        {
            var carData = Console.ReadLine().Split(' ');

            carList.Add(new Car(carData[0], double.Parse(carData[1]), double.Parse(carData[2])));
        }

        string driveCommand;

        while ((driveCommand = Console.ReadLine()) != "End")
        {
            var driveParameters = driveCommand.Split(' ');

            carList.First(n => n.Name == driveParameters[1]).Drive(double.Parse(driveParameters[2]));
        }

        foreach (var car in carList)
        {
            Console.WriteLine(car.ToString());
        }
    }
}

