namespace SIS.HTTP.Headers
{
    using System;
    using System.Collections.Generic;

    using Contracts;

    public class HttpHeaderCollection : IHttpHeaderCollection
    {
        private readonly Dictionary<string, HttpHeader> headers;

        public HttpHeaderCollection()
        {
            this.headers = new Dictionary<string, HttpHeader>();
        }

        public void Add(HttpHeader header)
        {
            if (header == null  ||
                string.IsNullOrEmpty(header.Key) ||
                string.IsNullOrEmpty(header.Value) ||
                this.ContainsHeader(header.Key))
            {
                throw new Exception();
            }

            this.headers.Add(header.Key, header);
        }

        public bool ContainsHeader(string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentException("Header key cannot be null or empty");
            }

            return this.headers.ContainsKey(key);
        }

        public HttpHeader GetHeader(string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentException("Header key cannot be null or empty");
            }

            bool headerExists = this.ContainsHeader(key);

            if (headerExists)
            {
                return headers[key];
            }

            return null;
        }

        public override string ToString()
        {
            return string.Join(Environment.NewLine, this.headers.Values);
        }
    }
}
