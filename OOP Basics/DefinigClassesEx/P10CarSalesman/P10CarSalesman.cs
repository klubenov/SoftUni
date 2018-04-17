using System;
using System.Collections.Generic;


class P10CarSalesman
{
    static void Main(string[] args)
    {
        int engineCount = int.Parse(Console.ReadLine());

        var engineList = new List<Engine>(engineCount);

        for (int i = 0; i < engineCount; i++)
        {
            var currentEngineData = Console.ReadLine().Split(new []{' '}, StringSplitOptions.RemoveEmptyEntries);

            if (currentEngineData.Length==2)
            {
                var currentEngine = new Engine(currentEngineData[0], int.Parse(currentEngineData[1]));
                engineList.Add(currentEngine);
            }
            else if (currentEngineData.Length==3)
            {
                if (int.TryParse(currentEngineData[2], out int displacement))
                {
                    var currentEngine = new Engine(currentEngineData[0], int.Parse(currentEngineData[1]), displacement);
                    engineList.Add(currentEngine);
                }
                else
                {
                    var currentEngine = new Engine(currentEngineData[0], int.Parse(currentEngineData[1]), currentEngineData[2]);
                    engineList.Add(currentEngine);
                }
            }
            else if (currentEngineData.Length == 4)
            {
                var currentEngine = new Engine(currentEngineData[0], int.Parse(currentEngineData[1]), currentEngineData[2], currentEngineData[3]);
                engineList.Add(currentEngine);
            }
        }

        var carCount = int.Parse(Console.ReadLine());

        var carList = new List<Car>();

        for (int i = 0; i < carCount; i++)
        {
            var currentCarData = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var model = currentCarData[0];

            var engine = engineList.Find(m => m.Model == currentCarData[1]);

            if (currentCarData.Length == 2)
            {
                carList.Add(new Car(model,engine));
            }
            else if (currentCarData.Length == 3)
            {
                if (int.TryParse(currentCarData[2], out int weight))
                {
                    carList.Add(new Car(model,engine,weight));
                }
                else
                {
                    carList.Add(new Car(model,engine,currentCarData[2]));
                }
            }
            else if (currentCarData.Length == 4)
            {
                carList.Add(new Car(model,engine,currentCarData[2], currentCarData[3]));
            }
        }

        foreach (var car in carList)
        {
            Console.WriteLine(car);
        }
    }
}

