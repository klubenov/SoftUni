using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P08MentorGroup
{
    public class User
    {
        public string Name { get; set; }
        public List<string> Comments { get; set; }
        public List<DateTime> Dates { get; set; }
    }

    class P08MentorGroup
    {
        static void Main(string[] args)
        {
            List<User> userList = new List<User>();
            string input = Console.ReadLine();
            while (input!="end of dates")
            {
                User currentUser = new User();
                currentUser.Dates = new List<DateTime>();
                string[] nameDate = input.Split(new char[] {' ', ','});
                if (!userList.Any(n => n.Name==nameDate[0]))
                {
                    currentUser.Name = nameDate[0];
                    for (int i = 1; i < nameDate.Length; i++)
                    {
                        currentUser.Dates.Add(DateTime.ParseExact(nameDate[i], "dd/MM/yyyy", CultureInfo.InvariantCulture ));
                    }
                    userList.Add(currentUser);
                    input = Console.ReadLine();
                    continue;
                }
                else
                {
                    for (int i = 1; i < nameDate.Length; i++)
                    {
                        userList.FirstOrDefault(n => n.Name==nameDate[0]).Dates.Add(DateTime.ParseExact(nameDate[i], "dd/MM/yyyy", CultureInfo.InvariantCulture));
                    }
                }
                input = Console.ReadLine();
            }
            input = Console.ReadLine();
            foreach (var user in userList)
            {
                user.Comments = new List<string>();
            }
            while (input != "end of comments")
            {
                string[] comments = input.Split('-');
                if (!userList.Any(n => n.Name == comments[0]))
                {
                    input = Console.ReadLine();
                    continue;
                }
                userList.FirstOrDefault(n => n.Name==comments[0]).Comments.Add(comments[1]);
                input = Console.ReadLine();
            }
            foreach (var user in userList.OrderBy(n => n.Name))
            {
                Console.WriteLine(user.Name+Environment.NewLine+"Comments:");
                foreach (var comment in user.Comments)
                {
                    Console.WriteLine($"- {comment}");
                }
                Console.WriteLine("Dates attended:");
                foreach (var date in user.Dates.OrderBy(d => d.Date))
                {
                    Console.WriteLine($"-- {date:dd/MM/yyyy}");
                }
            }
        }
    }
}
