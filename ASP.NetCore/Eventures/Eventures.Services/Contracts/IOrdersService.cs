using System;
using System.Collections.Generic;
using System.Text;
using Eventures.Services.Models;

namespace Eventures.Services.Contracts
{
    public interface IOrdersService
    {
        int Create(OrderBindingModel orderBindingModel, string username);

        OrderViewModel[] All();
    }
}
