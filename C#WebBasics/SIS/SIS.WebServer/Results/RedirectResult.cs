namespace SIS.WebServer.Results
{
    using HTTP.Headers;
    using HTTP.Responses;
    using HTTP.Enums;

    public class RedirectResult : HttpResponse
    {
        public RedirectResult(string location)
            :base(HttpResponseStatusCode.SeeOther)
        {
            this.Headers.Add(new HttpHeader("Location", location));
        }
    }
}
