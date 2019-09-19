using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Eventures.Data;
using Eventures.Models;
using Eventures.Services.Contracts;
using Eventures.Services.Models;
using Microsoft.AspNetCore.Identity;

namespace Eventures.Services.Implementations
{
    public class UsersService : IUsersService
    {
        private readonly UserManager<User> userManager;

        public UsersService(UserManager<User> userManager)
        {
            this.userManager = userManager;
        }

        public UserAllViewModel GetAllUsers()
        {
            var users = this.userManager.Users.ToArray();

            var userListViewModels = new List<UserListViewModel>();

            foreach (var user in users)
            {
                var userListViewModel = new UserListViewModel
                {
                    Username = user.UserName,
                    Roles = this.userManager.GetRolesAsync(user).Result
                };

                userListViewModels.Add(userListViewModel);
            }

            var userAllViewModel = new UserAllViewModel
            {
                Users = userListViewModels
            };

            return userAllViewModel;
        }

        public void Promote(string username)
        {
            var user = this.userManager.Users.First(u => u.UserName == username);

            this.userManager.AddToRoleAsync(user, "Admin").GetAwaiter().GetResult();
        }

        public void Demote(string username)
        {
            var user = this.userManager.Users.First(u => u.UserName == username);

            this.userManager.RemoveFromRoleAsync(user, "Admin").GetAwaiter().GetResult();
        }
    }
}
