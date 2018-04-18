using System;
using System.Collections.Generic;
using System.Linq;

public class Engine
{
    private DraftManager manager;

    public Engine(IProviderController providerController, IHarvesterController harvesterController)
    {
        this.manager = new DraftManager(providerController, harvesterController);
    }

    public void Run()
    {
        while (true)
        {
            var input = Console.ReadLine();
            var data = input.Split().ToList();
            var command = data[0];
            switch (command)
            {
                case "Register":
                    if (data[1] == "Harvester")
                    {
                        Console.WriteLine(manager.RegisterHarvester(data.Skip(2).ToList()));
                    }
                    else if(data[1] == "Provider")
                    {
                        Console.WriteLine(manager.RegisterProvider(data.Skip(2).ToList()));
                    }
                    break;
                case "Day":
                    Console.WriteLine(manager.Day());
                    break;
                case "Mode":
                    Console.WriteLine(manager.Mode(data.Skip(1).ToList()));
                    break;
                case "Inspect":
                    Console.WriteLine(manager.Check(data.Skip(1).ToList()));
                    break;
                case "Shutdown":
                    Console.WriteLine(manager.ShutDown());
                    Environment.Exit(0);
                    break;
            }
        }
    }
}
