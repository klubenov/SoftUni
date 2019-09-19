using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eventures.Services.Contracts;
using Eventures.Services.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Eventures.Web.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IOrdersService ordersService;

        public OrdersController(IOrdersService ordersService)
        {
            this.ordersService = ordersService;
        }

        [Authorize]
        [HttpPost]
        public IActionResult Create(OrderBindingModel orderBindingModel, int pageNumber)
        {
            var username = this.User.Identity.Name;

            if (this.ModelState.IsValid)
            {
                var result = this.ordersService.Create(orderBindingModel, username);

                if (result == -1)
                {
                    return RedirectToAction("Error");
                }
            }

            return RedirectToAction("All", "Events", new {currentPage = pageNumber});
        }

        [Authorize(Roles = "Admin")]
        public IActionResult All()
        {
            var model = this.ordersService.All();

            return View(model);
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
