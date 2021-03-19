using System.Web.Http;
using WebUserManagement.Api.Filters;

namespace WebUserManagement.Api.App_Start
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        { 
            config.MapHttpAttributeRoutes();
            config.Formatters.Remove(config.Formatters.XmlFormatter);
            config.Filters.Add(new ApiExceptionFilterAttribute());
            config.Filters.Add(new ValidationActionFilter());
        }
    }
}