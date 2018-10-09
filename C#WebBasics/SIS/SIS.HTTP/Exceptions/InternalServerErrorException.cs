namespace SIS.HTTP.Exceptions
{
    using System;

    using Enums;

    public class InternalServerErrorException : Exception
    {
        private const string ErrorMessage = "The Server has encountered an error.";

        public const HttpResponseStatusCode HttpStatusCode = HttpResponseStatusCode.InternalServerError;

        public InternalServerErrorException()
            : base(ErrorMessage)
        {

        }
    }
}
