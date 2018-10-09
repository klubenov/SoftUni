namespace SIS.HTTP.Sessions
{
    using System;
    using System.Collections.Generic;

    using Contracts;

    public class HttpSession : IHttpSession
    {
        private readonly Dictionary<string, object> parameters;

        public string Id { get; }

        public HttpSession(string id)
        {
            this.Id = id;
            this.parameters = new Dictionary<string, object>();
        }

        public object GetParameter(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException();
            }

            if (this.ContainsParameter(name))
            {
                return this.parameters[name];
            }

            return null;
        }

        public bool ContainsParameter(string name)
        {
            return this.parameters.ContainsKey(name);
        }

        public void AddParameter(string name, object parameter)
        {
            if (parameter == null)
            {
                throw new ArgumentException();
            }

            this.parameters[name] = parameter;
        }

        public void ClearParameters()
        {
            this.parameters.Clear();
        }
    }
}
