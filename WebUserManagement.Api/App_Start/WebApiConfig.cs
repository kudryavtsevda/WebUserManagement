using Ninject;
using Ninject.Modules;
using Ninject.Web.Mvc;
using System.Web.Http;
using System.Web.Mvc;

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

           
            //config.DependencyResolver = (System.Web.Http.Dependencies.IDependencyResolver)(IDependencyResolver) new NinjectDependencyResolver(kernel);
            //DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));
        }
    }
}