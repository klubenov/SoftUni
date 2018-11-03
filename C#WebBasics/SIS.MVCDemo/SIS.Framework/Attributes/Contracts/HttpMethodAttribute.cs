using System;

namespace SIS.Framework.Attributes.Contracts
{
    public abstract class HttpMethodAttribute : Attribute
    {
        public abstract bool IsValid(string requestMethod);
    }
}
