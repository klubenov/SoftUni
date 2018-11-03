using SIS.HTTP.Requests;
using SIS.HTTP.Responses;

namespace SIS.WebServer.Api.Contracts
{
    public interface IHttpHandlersContext
    {
        IHttpResponse Handle(IHttpRequest request);
    }
}
