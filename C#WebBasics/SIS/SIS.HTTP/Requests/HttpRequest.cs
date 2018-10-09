namespace SIS.HTTP.Requests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;


    using Common;
    using Enums;
    using Exceptions;
    using Headers;
    using Headers.Contracts;
    using Contracts;
    using Cookies;
    using Cookies.Contracts;
    using Sessions.Contracts;

    public class HttpRequest : IHttpRequest
    {
        public HttpRequest(string requestString)
        {
            this.FormData = new Dictionary<string, object>();
            this.QueryData = new Dictionary<string, object>();
            this.Headers = new HttpHeaderCollection();
            this.Cookies = new HttpCookieCollection();

            this.ParseRequest(requestString);
        }

        public string Path { get; private set; }

        public string Url { get; private set; }

        public Dictionary<string, object> FormData { get; }

        public Dictionary<string, object> QueryData { get; }

        public IHttpHeaderCollection Headers { get; }

        public IHttpCookieCollection Cookies { get; set; }

        public IHttpSession Session { get; set; }

        public HttpRequestMethod RequestMethod { get; private set; }



        private void ParseRequest(string requestString)
        {
            string[] splitRequestContent = requestString
                .Split(new[] {Environment.NewLine}, StringSplitOptions.None);

            string[] requestLine =
                splitRequestContent[0].Trim().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);

            if (!this.IsValidRequestLine(requestLine))
            {
                throw new BadRequestException();
            }

            //method
            this.ParseRequestMethod(requestLine);
            this.ParseRequestUrl(requestLine);
            this.ParseRequestPath();

            this.ParseHeaders(splitRequestContent.Skip(1).ToArray());
            this.ParseCookies();

            bool requestHasBody = splitRequestContent.Length > 1;
            this.ParseRequestParameters(splitRequestContent[splitRequestContent.Length - 1], requestHasBody);
        }

        private void ParseRequestParameters(string bodyParameters, bool requestHasBody)
        {
            this.ParseQueryParameters(this.Url);
            if (requestHasBody)
            {
                this.ParseFormDataParameters(bodyParameters);
            }
        }

        private void ParseFormDataParameters(string bodyParameters)
        {
            var formDataKeyValuePairs = bodyParameters.Split('&', StringSplitOptions.RemoveEmptyEntries);
            this.ExtractRequestParameters(formDataKeyValuePairs, this.FormData);
        }

        private void ParseQueryParameters(string url)
        {
            //var queryParameters = url
            //    .Split(new[] { '?', '#' })
            //    .Skip(1)
            //    .ToArray()[0];

            var splitUrl = url
                .Split(new[] {'?', '#'}).ToArray();

            if (splitUrl.Length<2)
            {
                return;
            }

            var queryParameters = splitUrl[1];


            if (string.IsNullOrEmpty(queryParameters))
            {
                throw new BadRequestException();
            }

            var queryKeyValuePairs = queryParameters.Split('&', StringSplitOptions.RemoveEmptyEntries);

            this.ExtractRequestParameters(queryKeyValuePairs, this.QueryData);
        }

        private void ParseHeaders(string[] requestHeaders)
        {
            if (!requestHeaders.Any())
            {
                throw new BadRequestException();
            }

            foreach (var requestHeader in requestHeaders)
            {
                if (string.IsNullOrEmpty(requestHeader))
                {
                    return;
                }

                var splitRequestHeader = requestHeader.Split(": ", StringSplitOptions.RemoveEmptyEntries);
                var requestHeaderKey = splitRequestHeader[0];
                var requestHeaderValue = splitRequestHeader[1];

                this.Headers.Add(new HttpHeader(requestHeaderKey, requestHeaderValue));
            }
        }

        private void ParseCookies()
        {
            if (!this.Headers.ContainsHeader("Cookie"))
            {
                return;
            }

            var cookiesHeader = this.Headers.GetHeader("Cookie");

            var cookieStrings = cookiesHeader.Value.Split("; ", StringSplitOptions.RemoveEmptyEntries);

            foreach (var cookieString in cookieStrings)
            {
                var cookieKeyValuePair = cookieString.Split("=",2);

                if (cookieKeyValuePair.Length != 2)
                {
                    throw new BadRequestException();
                }

                var cookieKey = cookieKeyValuePair[0];
                var cookieValue = cookieKeyValuePair[1];

                bool isNew = this.Cookies.ContainsCookie(cookieKey);

                var cookie = new HttpCookie(cookieKey, cookieValue, isNew);

                this.Cookies.Add(cookie);
            }
        }

        private void ParseRequestPath()
        {
            var path = this.Url.Split('?').FirstOrDefault();

            if (string.IsNullOrEmpty(path))
            {
                throw new BadRequestException();
            }

            this.Path = path;
        }

        private void ParseRequestUrl(string[] requestLine)
        {
            if (string.IsNullOrEmpty(requestLine[1]))
            {
                throw new BadRequestException();
            }

            this.Url = requestLine[1];
        }

        private void ParseRequestMethod(string[] requestLine)
        {
            var parseResult = Enum.TryParse<HttpRequestMethod>(requestLine[0],out var parsedMethod);

            if (parseResult)
            {
                throw new BadRequestException();
            }

            this.RequestMethod = parsedMethod;
        }

        private bool IsValidRequestLine(string[] requestLine)
        {
            if (!requestLine.Any())
            {
                throw new BadRequestException();
            }

            if (requestLine.Length == 3 &&
                requestLine[2] == GlobalConstants.HttpOneProtocolFragment)
            {
                return true;
            }

            return false;
        }

        private void ExtractRequestParameters(string[] parameterKeyValuePairs,
            Dictionary<string, object> parameterCollection)
        {
            foreach (var parameterKeyValuePair in parameterKeyValuePairs)
            {
                var keyValuePair = parameterKeyValuePair.Split('=', StringSplitOptions.RemoveEmptyEntries);
                if (keyValuePair.Length == 1)
                {
                    return;
                }
                if (keyValuePair.Length != 2)
                {
                    throw new BadRequestException();
                }
                var parameterKey = keyValuePair[0];
                var parameterValue = keyValuePair[1];

                parameterCollection[parameterKey] = parameterValue;
            }
        }

    }
}
