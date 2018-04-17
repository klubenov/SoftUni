using System;

namespace P09ReversedChars
{
    class P09ReversedChars
    {
        static void Main(string[] args)
        {
            char firstLetter = char.Parse(Console.ReadLine());
            char secondLetter = char.Parse(Console.ReadLine());
            char thirdLetter = char.Parse(Console.ReadLine());
            Console.WriteLine($"{thirdLetter}{secondLetter}{firstLetter}");
        }
    }
}