using System;
using System.Collections.Generic;
using System.Text;
using Eventures.Services.Models;

namespace Eventures.Services.Contracts
{
    public interface IUsersService
    {
        UserAllViewModel GetAllUsers();

        void Promote(string username);

        void Demote(string username);
    }
}
