using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SIS.Framework.ActionResults;
using SIS.Framework.Attributes.Method;
using SIS.Framework.Security;
using Torshia.App.Controllers.Base;
using Torshia.App.ViewModels.Users;
using Torshia.Models;
using Torshia.Models.Enums;

namespace Torshia.App.Controllers
{
    public class UsersController : BaseController
    {
        public IActionResult Login() => this.View();

        [HttpPost]
        public IActionResult Login(LoginViewModel loginViewModel)
        {
            var username = loginViewModel.Username;
            var password = loginViewModel.Password;

            var user = context.Users.FirstOrDefault(u => u.Username == username && u.Password == password);

            if (user == null)
            {
                this.ErrorMessage = "Invalid Username or Password";
                return this.View();
            }

            this.SignIn(new IdentityUser {Username = username, Email = user.Email, Roles = new List<string> { user.Role.ToString() } });

            return this.RedirectToAction("/");
        }

        public IActionResult Register() => this.View();

        [HttpPost]
        public IActionResult Register(RegisterViewModel registerViewModel)
        {
            var username = registerViewModel.Username;
            var password = registerViewModel.Password;
            var confirmPassword = registerViewModel.ConfirmPassword;
            var email = registerViewModel.Email;
            var role = Role.User;

            if (this.context.Users.Any(u => u.Username == username))
            {
                this.ErrorMessage = "Username taken! Please choose another username.";
                return this.View();
            }

            if (password != confirmPassword)
            {
                this.ErrorMessage = "Confirmed password does not match the entered password!";
                return this.View();
            }

            if (!context.Users.Any())
            {
                role = Role.Admin;
            }

            var user = new User
            {
                Username = username,
                Password = password,
                Email = email,
                Role = role   
            };

            this.context.Users.Add(user);
            this.context.SaveChanges();

            this.SignIn(new IdentityUser
            {
                Username = username,
                Email = email,
                Roles = new List<string> { role.ToString() }
            });

            return this.RedirectToAction("/");
        }

        public IActionResult Logout()
        { 
            this.SignOut();
            return this.RedirectToAction("/");
        }
    }
}
