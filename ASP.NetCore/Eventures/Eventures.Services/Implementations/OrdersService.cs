using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Eventures.Data;
using Eventures.Models;
using Eventures.Services.Contracts;
using Eventures.Services.Models;
using Microsoft.EntityFrameworkCore;

namespace Eventures.Services.Implementations
{
    public class OrdersService : IOrdersService
    {
        private readonly EventuresDbContext context;

        public OrdersService(EventuresDbContext context)
        {
            this.context = context;
        }


        public int Create(OrderBindingModel orderBindingModel, string username)
        {
            var customer = this.context.Users.FirstOrDefault(u => u.UserName == username);
            var eventInstance = this.context.Events.FirstOrDefault(e => e.Name == orderBindingModel.EventName);

            if (customer == null || eventInstance == null)
            {
                return 0;
            }

            if (orderBindingModel.TicketsCount > eventInstance.TotalTickets || orderBindingModel.TicketsCount < 1)
            {
                return -1;
            }

            var order = new Order
            {
                Customer = customer,
                Event = eventInstance,
                OrderedOn = DateTime.Now,
                TicketCount = orderBindingModel.TicketsCount
            };

            eventInstance.TotalTickets -= orderBindingModel.TicketsCount;

            this.context.Orders.Add(order);
            this.context.SaveChanges();

            return 1;
        }

        public OrderViewModel[] All()
        {
            var orders = this.context.Orders.Select(o => new OrderViewModel
            {
                CustomerName = o.Customer.UserName,
                EventName = o.Event.Name,
                OrderedOn = o.OrderedOn
            }).ToArray();

            return orders;
        }
    }
}
