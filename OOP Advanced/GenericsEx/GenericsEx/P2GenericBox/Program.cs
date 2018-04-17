using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;


class Program
{
    static void Main(string[] args)
    {
        int numberOfItems = int.Parse(Console.ReadLine());

        var listOfBoxes = new List<Box<double>>();

        for (int i = 0; i < numberOfItems; i++)
        {
            var box = new Box<double>(double.Parse(Console.ReadLine()));
            listOfBoxes.Add(box);
        }

        var boxToCompare = new Box<double>(double.Parse(Console.ReadLine()));

        int overalCompareResult = 0;

        foreach (var box in listOfBoxes)
        {
            var compareResult = boxToCompare.CompareTo(box);
            if (compareResult==1)
            {
                overalCompareResult++;
            }
        }

        Console.WriteLine(overalCompareResult);

        //var indices = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        //listOfBoxes = Box<int>.GenericSwap(listOfBoxes, indices).ToList();
        //foreach (var box in listOfBoxes)
        //{
        //    Console.WriteLine(box);
        //}
    }
}
