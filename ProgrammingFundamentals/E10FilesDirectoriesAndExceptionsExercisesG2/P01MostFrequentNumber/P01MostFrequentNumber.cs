using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace P01MostFrequentNumber
{
    class P01MostFrequentNumber
    {
        static void Main(string[] args)
        {
            string inputFilePath = "../../input.txt";
            string outputFilePath = "../../output.txt";
            File.WriteAllText(outputFilePath, String.Empty);
            string[] inputLines = File.ReadAllLines(inputFilePath);
            for (int n = 0; n < inputLines.Length; n++)
            {
                int[] numbers = inputLines[n]
                    .Split(' ')
                    .Select(int.Parse)
                    .ToArray();

                int bestCount = 0;
                int mostFrequentNumber = numbers[0];

                for (int i = 0; i < numbers.Length; i++)
                {
                    int counter = 0;
                    for (int j = i + 1; j < numbers.Length; j++)
                    {
                        if (numbers[i] == numbers[j])
                        {
                            counter++;
                        }

                    }
                    if (counter > bestCount)
                    {
                        bestCount = counter;
                        mostFrequentNumber = numbers[i];
                    }

                }
                File.AppendAllText(outputFilePath,mostFrequentNumber.ToString());
                File.AppendAllText(outputFilePath,Environment.NewLine);
            }
            
        }
    }
}
