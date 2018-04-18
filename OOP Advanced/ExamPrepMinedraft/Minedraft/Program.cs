using System.Collections.Generic;

public class Program
{
    public static void Main(string[] args)
    {
        IEnergyRepository energyRepository = new EnergyRepository();
        IHarvesterController harvesterController = new HarvesterController(energyRepository);
        IProviderController providerController = new ProviderController(energyRepository);
        ICommandInterpreter commandInterpreter = new CommandInterpreter(providerController,harvesterController);
        IWriter consoleWriter = new ConsoleWriter();
        IReader consoleReader = new ConsoleReader();

        Engine engine = new Engine(commandInterpreter, consoleWriter, consoleReader);
        engine.Run();

        //providerController.Register(new List<string>() {"Standart", "1", "1000"});
        //harvesterController.Register(new List<string>() {"Sonic", "3", "1000", "100"});
        //harvesterController.Register(new List<string>() { "Standart", "2", "1000", "100" });
        //harvesterController.Register(new List<string>() { "Hammer", "4", "1000", "100" });
        //harvesterController.Register(new List<string>() { "Infinity", "5", "1000", "100" });

        //harvesterController.ChangeMode("Half");
        //harvesterController.ChangeMode("Full");
        //harvesterController.ChangeMode("Half");
        //harvesterController.ChangeMode("Full");
        //harvesterController.ChangeMode("Half");
        //harvesterController.ChangeMode("Full");
        //harvesterController.ChangeMode("Half");
        //harvesterController.ChangeMode("Full");
        //harvesterController.ChangeMode("Half");
        //harvesterController.ChangeMode("Full");
        //providerController.Produce();
        //harvesterController.Produce();
        //harvesterController.ChangeMode("Half");
        //harvesterController.ChangeMode("Full");
        //harvesterController.ChangeMode("Half");
        //harvesterController.ChangeMode("Full");
    }
}