using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eventures.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Eventures.Web.Areas.Administration.Controllers
{
    [Area("Administration")]
    [Authorize(Roles = "Admin")]
    public class UsersController : Controller
    {
        private readonly IUsersService usersService;

        public UsersController(IUsersService usersService)
        {
            this.usersService = usersService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Roles()
        {
            var users = this.usersService.GetAllUsers();


            return View(users);
        }

        [HttpPost]
        public IActionResult Promote(string username)
        {
            this.usersService.Promote(username);

            return RedirectToAction("Roles", "Users");
        }

        [HttpPost]
        public IActionResult Demote(string username)
        {
            this.usersService.Demote(username);

            return RedirectToAction("Roles", "Users");
        }
    }
}