using System;
using System.Collections.Generic;
using System.Text;

namespace Eventures.Services.Models
{
    public class UserListViewModel
    {
        public string Username { get; set; }

        public IList<string> Roles { get; set; }
    }
}
