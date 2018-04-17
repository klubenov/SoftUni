using System;
using P1EventImplementation.Contracts;

namespace P1EventImplementation
{
    class Program
    {
        static void Main(string[] args)
        {
            INameChangeable dispatcher = new Dispatcher("Pesho");
            INameChangeHandler handler = new Handler();

            dispatcher.NameChange += handler.OnDispatcherNameChange;

            string input;

            while ((input=Console.ReadLine())!="End")
            {
                dispatcher.Name = input;
            }
        }
    }
}
