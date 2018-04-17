using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;


class Program
{
    static void Main(string[] args)
    {
        string pattern = @"(?<pattern>[A-Za-z]+)(.+)(\k<pattern>)";
        string input = Console.ReadLine();
        string[] placeholders = Console.ReadLine().Split(new[] { '}', '{' }, StringSplitOptions.RemoveEmptyEntries);
        MatchCollection matches = Regex.Matches(input, pattern);
        List<string> wordToBeReplaced = new List<string>();
        foreach (Match placeholder in matches)
        {
            wordToBeReplaced.Add(placeholder.Groups[1].ToString());
        }
        int replacedWords = 0;
        for (int i = 0; i < wordToBeReplaced.Count; i++)
        {
            if (i > placeholders.Length - 1)
            {
                break;
            }
            string word = wordToBeReplaced[i];
            int wordIndex = input.IndexOf(word);
            input = input.Remove(wordIndex, word.Length);
            input = input.Insert(wordIndex, placeholders[replacedWords]);
            replacedWords++;
        }
        Console.WriteLine(input);
    }
}
