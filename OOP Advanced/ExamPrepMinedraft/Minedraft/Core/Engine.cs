using System;
using System.Collections.Generic;
using System.Linq;

public class Engine
{
    private ICommandInterpreter commandInterpreter;
    private IWriter writer;
    private IReader reader;

    public Engine(ICommandInterpreter commandInterpreter, IWriter writer, IReader reader)
    {
        this.commandInterpreter = commandInterpreter;
        this.writer = writer;
        this.reader = reader;
    }

    public void Run()
    {
        while (true)
        {
            var input = reader.ReadLine().Trim();
            var data = input.Split(new char[]{' '}, StringSplitOptions.RemoveEmptyEntries).ToList();
            writer.WriteLine(commandInterpreter.ProcessCommand(data));
            if (input=="Shutdown")
            {
                Environment.Exit(0);
            }
        }
    }
}
