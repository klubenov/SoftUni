using System;
using System.Collections.Generic;
using Exam.Models.Enums;

namespace Exam.Models
{
    public class User
    {
        public User()
        {
            this.Receipts = new HashSet<Receipt>();
            this.Packages  = new HashSet<Package>();
        }

        public int Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public Role Role { get; set; }

        public ICollection<Receipt> Receipts { get; set; }

        public ICollection<Package> Packages { get; set; }
    }
}
