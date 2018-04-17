using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P04FixEmails
{
    class P04FixEmails
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string previousInput = "";
            int commandCount = 1;
            var emails = new Dictionary<string, string>();
            while (input != "stop")
            {
                if (commandCount % 2 == 1)
                {
                    if (!emails.ContainsKey(input)) emails.Add(input, null);
                }
                else
                {
                    emails[previousInput] = input;
                }
                previousInput = input;
                input = Console.ReadLine();
                commandCount++;
            }
            foreach (var email in emails.Where(email => email.Value.EndsWith("us")).ToDictionary(email => email.Key, email => email.Value))
                emails.Remove(email.Key);
            foreach (var email in emails)
            {
                Console.WriteLine($"{email.Key} -> {email.Value}");
            }
        }
    }
}
