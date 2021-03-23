using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace WebUserManagement.Api.Filters
{
    public class ValidationActionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {          
            if (!actionContext.ModelState.IsValid)
            {
                actionContext.Response = actionContext.Request
                     .CreateErrorResponse(HttpStatusCode.BadRequest, string.Join(";", actionContext.ModelState.Values.SelectMany(v => v.Errors).Select(x => x.ErrorMessage)));
            }
        }
    }
}