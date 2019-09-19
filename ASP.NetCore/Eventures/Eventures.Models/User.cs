using System;
using System.Collections.Generic;

namespace Eventures.Models
{
    using Microsoft.AspNetCore.Identity;

    public class User : IdentityUser
    {
        public string  FirstName { get; set; }

        public string LastName { get; set; }

        public string  UCN { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
