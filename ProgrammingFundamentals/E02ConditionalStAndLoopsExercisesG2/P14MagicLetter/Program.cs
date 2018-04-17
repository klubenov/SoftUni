using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P14MagicLetter
{
    class Program
    {
        static void Main(string[] args)
        {
            char firstLet = char.Parse(Console.ReadLine());
            char secondLet = char.Parse(Console.ReadLine());
            char oddLet = char.Parse(Console.ReadLine());
            for (char i = firstLet; i <=secondLet; i++)
            {
                for (char j = firstLet; j <= secondLet; j++)
                {
                    for (char k = firstLet; k <= secondLet; k++)
                    {
                        string currComb = i.ToString() + j.ToString() + k.ToString();
                        if(!currComb.Contains(oddLet)) Console.Write($"{currComb} ");
                    }
                }
            }
        }
    }
}
