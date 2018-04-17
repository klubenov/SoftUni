using System;
using System.Collections.Generic;
using System.Linq;


class P9RectangleIntersection
{
    static void Main(string[] args)
    {
        var commandsCount = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

        var rectangleDict = new Dictionary<string,Rectangle>();

        for (int i = 0; i < commandsCount[0]; i++)
        {
            var rectangleParameters = Console.ReadLine().Split(' ');

            rectangleDict.Add(rectangleParameters[0],new Rectangle(double.Parse(rectangleParameters[1]), double.Parse(rectangleParameters[2]), double.Parse(rectangleParameters[3]), double.Parse(rectangleParameters[4])));
        }

        for (int i = 0; i < commandsCount[1]; i++)
        {
            var intersectCheckValues = Console.ReadLine().Split(' ');

            if (rectangleDict[intersectCheckValues[0]].IntersectsWith(rectangleDict[intersectCheckValues[1]]))
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine("false");
            }
        }
    }
}

