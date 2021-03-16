using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebUserManagement.Api.Exceptions
{
    public class BadRequestException : CustomApiException
    {
        public BadRequestException(string message) : base(StatusCode.BadRequest, message)
        {

        }
    }
}