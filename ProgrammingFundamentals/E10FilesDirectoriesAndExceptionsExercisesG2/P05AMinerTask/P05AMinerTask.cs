using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P05AMinerTask
{
    class P05AMinerTask
    {
        static void Main(string[] args)
        {
            string inputFilePath = "../../input.txt";
            string outputFilePath = "../../output.txt";
            File.WriteAllText(outputFilePath, String.Empty);
            string[] inputLines = File.ReadAllLines(inputFilePath);
            var resources = new Dictionary<string, int>();
            for (int i = 1; i < inputLines.Length; i+=2)
            {

                if (!resources.ContainsKey(inputLines[i-1]))
                {
                    resources.Add(inputLines[i-1], int.Parse(inputLines[i]));
                }
                else
                {
                    resources[inputLines[i - 1]] += int.Parse(inputLines[i]);
                }
            }
            foreach (var resource in resources)
            {
                File.AppendAllText(outputFilePath, $"{resource.Key} -> {resource.Value}");
                File.AppendAllText(outputFilePath, Environment.NewLine);
            }
        }
    }
}
