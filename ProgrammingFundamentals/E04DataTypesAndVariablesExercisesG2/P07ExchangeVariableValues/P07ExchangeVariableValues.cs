using System;

namespace P07ExchangeVariableValues
{
    class P07ExchangeVariableValues
    {
        static void Main(string[] args)
        {
            byte a = 5;
            byte b = 10;
            Console.WriteLine($"Before:\na = {a}\nb = {b}\nAfter:\na = {b}\nb = {a}");
        }
    }
}
