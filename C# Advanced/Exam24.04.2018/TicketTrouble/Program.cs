using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace TicketTrouble
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"\{\S*\[([A-Z]{3} [A-Z]{2})\]\S*\[([A-Z]\d{2})\]\S*\}|\[\S*\{([A-Z]{3} [A-Z]{2})\}\S*\{([A-Z]\d{2})\}\S*\]";

            Regex regex = new Regex(pattern);

            string location = Console.ReadLine();

            string ticketsString = Console.ReadLine();

            MatchCollection matches = regex.Matches(ticketsString);

            List<string> tickets = new List<string>();
            string[] validTickets = new string[2];

            foreach (Match ticket in matches)
            {
                var dfsd = ticket.Groups[1].Value;
                if (ticket.Value.StartsWith('{'))
                {
                    if (ticket.Groups[1].Value == location)
                    {
                        tickets.Add(ticket.Groups[2].Value);
                    }
                }
                else
                {
                    if (ticket.Groups[3].Value == location)
                    {
                        tickets.Add(ticket.Groups[4].Value);
                    }
                }

            }

            if (validTickets.Length==2)
            {
                Console.WriteLine($"You are traveling to {location} on seats {tickets[0]} and {tickets[1]}.");
                Environment.Exit(0);
            }
            //else
            //{
            //    for (int i = 0; i < tickets.Count; i++)
            //    {
            //        for (int j = i+1; j < tickets.Count; j++)
            //        {
            //            if(tickets)
            //        }
            //    }
            //}

        }
    }
}
