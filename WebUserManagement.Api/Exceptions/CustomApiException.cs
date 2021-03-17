using System;

namespace WebUserManagement.Api.Exceptions
{
    public abstract class CustomApiException : Exception
    {
        public enum StatusCode
        {
            NotFound = 404,
            BadRequest = 400
        }

        protected CustomApiException(StatusCode code, string message) : base(message)
        {
            Code = code;
        }

        public StatusCode Code { get; }
    }
}