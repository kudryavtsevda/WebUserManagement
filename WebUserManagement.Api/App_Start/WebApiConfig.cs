using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Web.Http;

namespace WebUserManagement.Api.App_Start
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
           
            // Enable attribute routing
            config.MapHttpAttributeRoutes();

            // Disable default route map, to enforce attribute routing
            //config.Routes.MapHttpRoute(
            //    name: "DefaultApi",
            //    routeTemplate: "api/{controller}/{id}",
            //    defaults: new { id = RouteParameter.Optional }
            //);


            // We don't need the xml formatter
            config.Formatters.Remove(config.Formatters.XmlFormatter);
        }
    }
}