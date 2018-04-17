using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P4MaxSequenceOfEqualElements
{
    class P4MaxSequenceOfEqualElements
    {
        static void Main(string[] args)
        {
            string inputFilePath = "../../input.txt";
            string outputFilePath = "../../output.txt";
            File.WriteAllText(outputFilePath, String.Empty);
            string[] inputLines = File.ReadAllLines(inputFilePath);
            for (int n = 0; n < inputLines.Length; n++)
            {
                int[] arr = inputLines[n].Split(' ').Select(int.Parse).ToArray();
                int start = 0;
                int bestStart = 0;
                int length = 1;
                int bestLenght = 0;
                for (int i = 1; i <= arr.Length - 1; i++)
                {
                    if (arr[i] == arr[i - 1])
                    {
                        length++;
                        if (length > bestLenght)
                        {
                            bestStart = start;
                            bestLenght = length;
                        }
                    }
                    else
                    {
                        start = i;
                        length = 1;
                    }

                }
                if (bestLenght == 0)
                {
                    File.AppendAllText(outputFilePath, arr[0].ToString());
                }
                for (int i = bestStart; i <= bestStart + bestLenght - 1; i++)
                {
                    File.AppendAllText(outputFilePath, $"{arr[i]} ");
                }
                File.AppendAllText(outputFilePath, Environment.NewLine);
            }

        }
    }
}
