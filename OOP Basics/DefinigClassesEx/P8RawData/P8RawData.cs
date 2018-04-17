using System;
using System.Collections.Generic;
using System.Linq;


class P8RawData
{
    static void Main(string[] args)
    {
        int carCount = int.Parse(Console.ReadLine());

        var carList = new List<Car>(carCount);

        for (int i = 0; i < carCount; i++)
        {
            var carData = Console.ReadLine().Split(' ');

            var newCarEngine = new Engine(int.Parse(carData[1]), int.Parse(carData[2]));

            var newCarCargo = new Cargo(int.Parse(carData[3]), carData[4]);

            var newCarTyres = new Tyre[4];

            newCarTyres[0]= new Tyre(double.Parse(carData[5]), int.Parse(carData[6]));
            newCarTyres[1] = new Tyre(double.Parse(carData[7]), int.Parse(carData[8]));
            newCarTyres[2] = new Tyre(double.Parse(carData[9]), int.Parse(carData[10]));
            newCarTyres[3] = new Tyre(double.Parse(carData[11]), int.Parse(carData[12]));

            carList.Add(new Car(carData[0], newCarEngine, newCarCargo, newCarTyres));
        }
        var filter = Console.ReadLine();

        if (filter=="flamable")
        {
            foreach (var car in carList.Where(n=>n.Cargo.Type==filter&&n.Engine.Power>250))
            {
                Console.WriteLine(car.Name);
            }
        }
        else
        {
            foreach (var car in carList.Where(n=>n.Cargo.Type==filter && tyreWithLowPressureExistance(n)))
            {
                Console.WriteLine(car.Name);
            }
        }
    }

    public static Func<Car, bool> tyreWithLowPressureExistance = car =>
    {
        bool result = false;
        foreach (var tyre in car.Tyres)
        {
            if (tyre.Pressure < 1)
            {
                result = true;
                break;
            }
        }
        return result;
    };
}

