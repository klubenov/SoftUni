using Eventures.Services.Models;

namespace Eventures.Services.Contracts
{
    public interface IEventsService
    {
        void Create(EventCreateBindingModel model);

        EventAllViewModel All();

        EventMyViewModel[] My(string username);


    }
}
