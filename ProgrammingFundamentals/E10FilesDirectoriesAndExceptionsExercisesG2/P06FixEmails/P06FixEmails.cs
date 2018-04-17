using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P06FixEmails
{
    class P06FixEmails
    {
        static void Main(string[] args)
        {
            string inputFilePath = "../../input.txt";
            string outputFilePath = "../../output.txt";
            File.WriteAllText(outputFilePath, String.Empty);
            string[] inputLines = File.ReadAllLines(inputFilePath);
            var emails = new Dictionary<string, string>();
            for (int i = 1; i < inputLines.Length; i += 2)
            {
                    emails.Add(inputLines[i - 1], inputLines[i]);
            }
            foreach (var email in emails.Where(i => !i.Value.EndsWith("us")&& !i.Value.EndsWith("uk")))
            {
                File.AppendAllText(outputFilePath, $"{email.Key} -> {email.Value}");
                File.AppendAllText(outputFilePath, Environment.NewLine);
            }
        }
    }
}
