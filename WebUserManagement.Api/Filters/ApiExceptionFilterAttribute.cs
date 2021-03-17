using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;
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