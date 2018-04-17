using System;


class P5DateModifier
{
    static void Main(string[] args)
    {
        var firstDate = Console.ReadLine();
        var secondDate = Console.ReadLine();

        var twoDatesTuple = new TwoDateTuple(firstDate,secondDate);

        Console.WriteLine(twoDatesTuple.CalculateDifferenceInDates());
    }
}

