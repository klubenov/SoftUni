using System;

namespace P10CenturiesToNanoseconds
{
    class P10CenturiesToNanoseconds
    {
        static void Main(string[] args)
        {
            int centuries = byte.Parse(Console.ReadLine());
            int years = centuries * 100;
            int days = (int)(years * 365.2422);
            int hours = days * 24;
            int minutes = hours * 60;
            ulong seconds = (ulong)minutes * 60;
            ulong miliSeconds = seconds * 1000;
            ulong microSeconds = miliSeconds * 1000;
            decimal nanoSeconds = microSeconds * 1000M;
            Console.WriteLine($"{centuries} centuries = {years} years = {days} days = {hours} hours = {minutes} minutes = {seconds} seconds = {miliSeconds} milliseconds = {microSeconds} microseconds = {nanoSeconds} nanoseconds");
        }
    }
}
