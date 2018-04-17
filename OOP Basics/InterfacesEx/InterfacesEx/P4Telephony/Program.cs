using System;


public class Program
{
    static void Main(string[] args)
    {
        var smartphone = new Smartphone(Console.ReadLine().Split(' '), Console.ReadLine().Split(' '));

        foreach (var number in smartphone.PhoneNumbersArray)
        {
            Console.WriteLine(smartphone.CallNumber(number));
        }

        foreach (var site in smartphone.SitesArray)
        {
            Console.WriteLine(smartphone.BrowseSite(site));
        }
    }
}

