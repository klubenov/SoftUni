using System;
using System.Collections.Generic;
using System.Text;
using Exam.App.BindingModels;
using Exam.App.Controllers.Base;
using Exam.Data;
using SIS.Framework.ActionResults;
using SIS.Framework.Attributes.Method;
using System.Linq;
using Exam.Models;
using Exam.Models.Enums;
using SIS.Framework.Security;

namespace Exam.App.Controllers
{
    public class UsersController : BaseController
    {
        public UsersController(ExamDbContext context)
            : base(context)
        {

        }

        public IActionResult Login() => this.View();
        
        [HttpPost]
        public IActionResult Login(LoginBindingModel bindingModel)
        {
            var username = bindingModel.Username;
            var password = bindingModel.Password;

            var user = context.Users.FirstOrDefault(u => u.Username == username && u.Password == password);

            if (user == null)
            {
                return this.View();
            }

            this.SignIn(new IdentityUser {
                Username = username,
                Email = user.Email,
                Roles = new List<string> { user.Role.ToString() }
                });

            return this.RedirectToAction("/");
        }


        public IActionResult Register() => this.View();

        [HttpPost]
        public IActionResult Register(RegisterBindingModel bindingModel)
        {
            var username = bindingModel.Username;
            var password = bindingModel.Password;
            var confirmPassword = bindingModel.ConfirmPassword;
            var email = bindingModel.Email;
            var role = Role.User;

            if (this.context.Users.Any(u => u.Username == username))
            {
                return this.View();
            }

            if (password != confirmPassword)
            {
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
