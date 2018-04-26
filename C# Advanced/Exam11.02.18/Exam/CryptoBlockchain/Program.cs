using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace CryptoBlockchain
{
    class Program
    {
        static void Main(string[] args)
        {
            int lineCount = int.Parse(Console.ReadLine());
            string wholeChain = string.Empty;
            var result = new List<char>();

            for (int i = 0; i < lineCount; i++)
            {
                wholeChain += Console.ReadLine();
            }

            string pattern = @"[[{].*?(\d{3,}).*?[]}]";

            Regex regex = new Regex(pattern);

            MatchCollection matches = regex.Matches(wholeChain);

            foreach (Match match in matches)
            {
                char openingBracket = match.Value[0];
                char closingBracket = match.Value[match.Value.Length - 1];

                if ((int)openingBracket + 2 != (int)closingBracket)
                {
                    continue;
                }

                var digits = match.Groups[1].Value;

                if (digits.Length%3!=0)
                {
                    continue;
                }

                for (int i = 0; i < digits.Length; i+=3)
                {
                    var numberString = digits[i].ToString() + digits[i + 1].ToString() 
                        + digits[i + 2].ToString();

                    var charNumber = int.Parse(numberString) - match.Value.Length;
                    result.Add((char)charNumber);
                }
            }

            Console.WriteLine(string.Join("",result));
        }
    }
}
