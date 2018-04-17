using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P02IndexOfLetters
{
    class P02IndexOfLetters
    {
        static void Main(string[] args)
        {
            string inputFilePath = "../../input.txt";
            string outputFilePath = "../../output.txt";
            File.WriteAllText(outputFilePath, String.Empty);
            string[] inputLines = File.ReadAllLines(inputFilePath);
            for (int n = 0; n < inputLines.Length; n++)
            {
                char[] alpha = new char[26];
                for (int i = 97; i <= 122; i++)
                {
                    alpha[i - 97] = (char)i;
                }
                char[] input = inputLines[n].ToCharArray();
                for (int i = 0; i < input.Length; i++)
                {
                    for (int j = 0; j < alpha.Length; j++)
                    {
                        if (input[i] == alpha[j])
                        {
                            //Console.WriteLine($"{input[i]} -> {j}");
                            File.AppendAllText(outputFilePath, $"{input[i]} -> {j}");
                            File.AppendAllText(outputFilePath, Environment.NewLine);
                        }
                    }
                }
            }
        }
    }
}
