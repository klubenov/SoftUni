using System;
using System.Collections.Generic;
using System.Linq;
using Eventures.Services.Shared;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Eventures.Web.Controllers
{
    using Eventures.Services.Contracts;
    using Eventures.Services.Models;
    using Eventures.Web.Middleware;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class EventsController : Controller
    {
        private readonly IEventsService eventsService;

        public EventsController(IEventsService eventsService)
        {
            this.eventsService = eventsService;
        }

        [Authorize(Roles ="Admin")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [TypeFilter(typeof(LogEventCreateActionFilter))]
        public IActionResult Create(EventCreateBindingModel model)
        {
            if (ModelState.IsValid)
            {
                eventsService.Create(model);
                return Redirect("/");
            }

            return View(model);
        }

        [Authorize]
        public IActionResult All(int currentPage = 1)
        {
            var model = eventsService.All();

            if (currentPage > model.TotalPages)
            {
                currentPage--;
            }

            model.CurrentPage = currentPage;

            var pageEvents = new List<EventViewModel>();

            for (int i = 0; i < Constants.EventsPageListCount; i++)
            {
                var previousEventCounter = (currentPage - 1) * Constants.EventsPageListCount + i;

                if (previousEventCounter == model.Events.Count())
                {
                    break;
                }

                pageEvents.Add(model.Events.Skip(previousEventCounter).First());
            }

            model.Events = pageEvents;

            return View(model);
        }

        [Authorize]
        public IActionResult My()
        {
            var username = this.User.Identity.Name;

            var model = eventsService.My(username);

            return View(model);
        }

        public IActionResult Error()
        {
            return this.View();
        }
    }
}