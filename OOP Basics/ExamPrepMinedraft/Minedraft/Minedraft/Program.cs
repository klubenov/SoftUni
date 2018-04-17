using System;
using System.Linq;


class Program
{
    static void Main(string[] args)
    {
        string input;
        var draftManager = new DraftManager();

        while ((input=Console.ReadLine())!="Shutdown")
        {
            var inputData = input.Split(' ').ToList();

            switch (inputData[0])
            {
                case "RegisterHarvester":
                    inputData.RemoveAt(0);
                    Console.WriteLine(draftManager.RegisterHarvester(inputData));
                    break;
                case "RegisterProvider":
                    inputData.RemoveAt(0);
                    Console.WriteLine(draftManager.RegisterProvider(inputData));
                    break;
                case "Day":
                    Console.WriteLine(draftManager.Day());
                    break;
                case "Mode":
                    inputData.RemoveAt(0);
                    Console.WriteLine(draftManager.Mode(inputData));
                    break;
                case "Check":
                    inputData.RemoveAt(0);
                    Console.WriteLine(draftManager.Check(inputData));
                    break;
            }
        }
        
        Console.WriteLine(draftManager.ShutDown());
    }
}

