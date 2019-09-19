using System;
using System.Collections.Generic;
using System.Globalization;
using Eventures.Data;
using Eventures.Models;
using Eventures.Services.Contracts;
using Eventures.Services.Models;
using System.Linq;
using Eventures.Services.Shared;
using Microsoft.EntityFrameworkCore;

namespace Eventures.Services.Implementations
{
    public class EventsService : IEventsService
    {
        private readonly EventuresDbContext context;

        public EventsService(EventuresDbContext context)
        {
            this.context = context;
        }

        public void Create(EventCreateBindingModel model)
        {
            var eventInstance = new Event
            {
                End = DateTime.ParseExact(model.EndString, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture),
                Start = DateTime.ParseExact(model.StartString, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture),
                Name = model.Name,
                Place = model.Place,
                PricePerTicket = model.PricePerTicket,
                TotalTickets = model.TotalTickets,
            };

            context.Events.Add(eventInstance);
            context.SaveChanges();
        }

        public EventAllViewModel All()
        {
            var events = context.Events.Where(e => e.TotalTickets > 0)
                .Select(x => new EventViewModel
                {
                    End = x.End,
                    TicketsRemaining = x.TotalTickets,
                    Start = x.Start,
                    Name = x.Name
                })
                .ToArray();

            for (int i = 0; i < events.Length; i++)
            {
                events[i].Number = i + 1;
            }

            var eventAllViewModel = new EventAllViewModel
            {
                Events = events
            };

            if (eventAllViewModel.Events.Count() % Constants.EventsPageListCount == 0)
            {
                eventAllViewModel.TotalPages = eventAllViewModel.Events.Count() / Constants.EventsPageListCount;
            }
            else
            {
                eventAllViewModel.TotalPages = eventAllViewModel.Events.Count() / Constants.EventsPageListCount + 1;
            }

            return eventAllViewModel;
        }

        public EventMyViewModel[] My(string username)
        {
            var orders = this.context.Orders.Include(o => o.Event).Where(o => o.Customer.UserName == username).ToArray();

            var events = new List<EventMyViewModel>();

            foreach (var order in orders)
            {
                var eventViewModelInstance = events.FirstOrDefault(e => e.Name == order.Event.Name);

                if (eventViewModelInstance == null)
                {
                    events.Add(new EventMyViewModel
                    {
                        Name = order.Event.Name,
                        Start = order.Event.Start,
                        End = order.Event.End,
                        Tickets = order.TicketCount
                    });
                }
                else
                {
                    eventViewModelInstance.Tickets += order.TicketCount;
                }
            }

            var ordersEvents = this.context.Orders.Where(o => o.Customer.UserName == username).Select(o =>
                new EventMyViewModel
                {
                    Name = o.Event.Name,
                    Start = o.Event.Start,
                    End = o.Event.End,
                    Tickets = o.TicketCount
                }).ToArray();

            for (int i = 0; i < events.Count; i++)
            {
                events[i].Number = i + 1;
            }

            return events.ToArray();
        }
    }
}
