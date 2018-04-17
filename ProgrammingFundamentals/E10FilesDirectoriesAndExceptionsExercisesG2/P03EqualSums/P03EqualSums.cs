using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P03EqualSums
{
    class P03EqualSums
    {
        static void Main(string[] args)
        {
            string inputFilePath = "../../input.txt";
            string outputFilePath = "../../output.txt";
            File.WriteAllText(outputFilePath, String.Empty);
            string[] inputLines = File.ReadAllLines(inputFilePath);
            for (int n = 0; n < inputLines.Length; n++)
            {
                int[] numArr = inputLines[n].Split(' ').Select(int.Parse).ToArray();
                if (numArr.Length <= 1)
                {
                    File.AppendAllText(outputFilePath, 0.ToString());
                    File.AppendAllText(outputFilePath, Environment.NewLine);
                    continue;
                }
                int checker = 0;
                for (int i = 0; i < numArr.Length; i++)
                {
                    int leftSum = 0;
                    int rightSum = 0;
                    for (int j = 0; j < i; j++)
                    {
                        leftSum += numArr[j];
                    }
                    for (int j = i + 1; j < numArr.Length; j++)
                    {
                        rightSum += numArr[j];
                    }
                    if (rightSum == leftSum)
                    {
                        File.AppendAllText(outputFilePath, i.ToString());
                        File.AppendAllText(outputFilePath, Environment.NewLine);
                        checker++;
                        break;
                    }
                }
                if (checker==0)
                {
                    File.AppendAllText(outputFilePath, "no");
                    File.AppendAllText(outputFilePath, Environment.NewLine);
                }
            }
        }
    }
}
