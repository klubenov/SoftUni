using System;

namespace P01HelloName_
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            PrintName(name);
        }

        static void PrintName(string nameValue)
        {
            Console.WriteLine($"Hello, {nameValue}!");
        }
    }
}
