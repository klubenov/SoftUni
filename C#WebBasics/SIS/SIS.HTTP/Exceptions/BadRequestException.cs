namespace SIS.HTTP.Exceptions
{
    using System;

    using Enums;

    public class BadRequestException : Exception
    {
        private const string ErrorMessage = "The Request was malformed or contains unsupported elements.";

        public const HttpResponseStatusCode HttpStatusCode = HttpResponseStatusCode.BadRequest;

        public BadRequestException()
            : base(ErrorMessage)
        {
            
        }
    }
}
