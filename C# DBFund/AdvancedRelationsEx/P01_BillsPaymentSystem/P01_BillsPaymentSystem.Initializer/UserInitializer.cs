using System;
using System.Collections.Generic;
using System.Text;
using P01_BillsPaymentSystem.Data.Models;

namespace P01_BillsPaymentSystem.Initializer
{
    internal class UserInitializer
    {
        public static User[] GetUsers()
        {
            User[] users = new User[]
            {
                new User() {FirstName = "Dave", LastName = "Mustaine", Email = "dave@megadeth.com", Password = "meow"},
                new User()
                {
                    FirstName = "James",
                    LastName = "Hetfield",
                    Email = "james@metallica.com",
                    Password = "bau"
                },
                new User() {FirstName = "Leo", LastName = "Messi", Email = "leo@barcelona.com", Password = "shoot"},
                new User()
                {
                    FirstName = "Todor",
                    LastName = "Kiselichkov",
                    Email = "tosheto@naftata.com",
                    Password = "rit"
                }
            };

            return users;
        }
    }
}
