namespace SIS.HTTP.Responses
{
    using System;
    using System.Text;
    using System.Linq;

    using Enums;
    using Headers;
    using Headers.Contracts;
    using Contracts;
    using Common;
    using Extensions;
    using Cookies.Contracts;
    using Cookies;


    public class HttpResponse : IHttpResponse
    {
        public HttpResponse()
        {
            
        }

        public HttpResponse(HttpResponseStatusCode statusCode)
        {
            this.Headers = new HttpHeaderCollection();
            this.Content = new byte[0];
            this.StatusCode = statusCode;
            this.Cookies = new HttpCookieCollection();
        }

        public HttpResponseStatusCode StatusCode { get; set; }

        public IHttpHeaderCollection Headers { get; }

        public IHttpCookieCollection Cookies { get; }

        public byte[] Content { get; set; }

        public void AddHeader(HttpHeader header)
        {
            this.Headers.Add(header);
        }

        public void AddCookie(HttpCookie cookie)
        {
            if (cookie == null)
            {
                throw new ArgumentException();
            }

            this.Cookies.Add(cookie);
        }

        public byte[] GetBytes()
        {
            return Encoding.UTF8.GetBytes(this.ToString()).Concat(this.Content).ToArray();
        }

        public override string ToString()
        {
            var result = new StringBuilder();

            result.AppendLine($"{GlobalConstants.HttpOneProtocolFragment} {this.StatusCode.GetResponseLine()}")
                .AppendLine(this.Headers.ToString());

            if (this.Cookies.HasCookies())
            {
                result.AppendLine($"Set-Cookie: {this.Cookies}");
            }

            result.AppendLine();

            return result.ToString();
        }
    }
}
