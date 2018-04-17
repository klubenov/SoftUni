using System;

namespace P17PrintPartOfASCIITable
{
    class P17PrintPartOfASCIITable
    {
        static void Main(string[] args)
        {
            int startNum = int.Parse(Console.ReadLine());
            int finalNum = int.Parse(Console.ReadLine());
            for (int i = startNum; i <= finalNum; i++)
            {
                char currentChar = (char)i;
                Console.Write($"{currentChar} ");
            }
        }
    }
}