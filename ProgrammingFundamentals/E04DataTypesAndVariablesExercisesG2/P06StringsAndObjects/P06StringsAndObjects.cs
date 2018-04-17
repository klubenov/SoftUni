using System;

namespace P06StringsAndObjects
{
    class P06StringsAndObjects
    {
        static void Main(string[] args)
        {
            string hello = "Hello";
            string world = "World";
            object temp = hello + " " + world;
            string helloWorld = (string)temp;
            Console.WriteLine(helloWorld);
        }
    }
}
