using System;

namespace P05WordsInPlural
{
    class Program
    {
        static void Main(string[] args)
        {
            string noun = Console.ReadLine();
            bool endY = noun.EndsWith("y");
            bool endO = noun.EndsWith("o");
            bool endCH = noun.EndsWith("ch");
            bool endS = noun.EndsWith("s");
            bool endSH = noun.EndsWith("sh");
            bool endX = noun.EndsWith("x");
            bool endZ = noun.EndsWith("z");
            if (endY)
            {
                int strLength = noun.Length;
                string withOutY = noun.Remove(strLength-1);
                Console.WriteLine(withOutY + "ies");
            }
            else if(endO||endCH||endS||endSH||endX||endZ)
                Console.WriteLine(noun+"es");
            else Console.WriteLine(noun+"s");
        }
    }
}
