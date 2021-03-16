using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Filters;
using System.Web.Http.Results;
using System.Web.Mvc;
using WebUserManagement.Api.Exceptions;

namespace WebUserManagement.Api.Filters
{
    public class ApiExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            var exception = context.Exception as CustomApiException;
            if (exception != null)
            {
                context.Response = context.Request.CreateErrorResponse((HttpStatusCode)exception.Code, exception.Message);
            }
            else 
            {
                context.Response = context.Request.CreateErrorResponse(HttpStatusCode.InternalServerError, context.Exception.Message);
            }
        }
    }
}