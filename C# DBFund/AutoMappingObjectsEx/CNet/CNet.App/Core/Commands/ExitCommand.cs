namespace CNet.App.Core.Commands
{
    using System;

    using Contracts;
    using Dtos;

    class ExitCommand : ICommand
    {
        public string Execute(string[] args)
        {
            Console.WriteLine(@"Do you really want to exit: y\n");
            while (true)
            {
                var action = Console.ReadKey().Key;

                if (action==ConsoleKey.Y)
                {
                    Environment.Exit(0);
                }
                else if(action == ConsoleKey.N)
                {
                    return "Please choose another command";
                }
                else
                {
                    Console.WriteLine(@"Please enter 'y' or 'n'!");
                }
            }
        }
    }
}

