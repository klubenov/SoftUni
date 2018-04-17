using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P09IndexOfLetters
{
    class P09IndexOfLetters
    {
        static void Main(string[] args)
        {
            char[] alpha = new char[26];
            for (int i = 97; i <= 122; i++)
            {
                alpha[i - 97] = (char) i;
            }
            char[] input = Console.ReadLine().ToCharArray();
            for (int i = 0; i < input.Length; i++)
            {
                for (int j = 0; j < alpha.Length; j++)
                {
                    if (input[i] == alpha[j])
                    {
                        Console.WriteLine($"{input[i]} -> {j}");
                    }
                }
            }
        }
    }
}
