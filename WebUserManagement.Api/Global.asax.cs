using System.Web.Http;
using WebUserManagement.Api.App_Start;
using WebUserManagement.Api.App_Start.DIConfig;

namespace WebUserManagement.Api
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            NinjectHttpContainer.RegisterModules(NinjectHttpModules.Modules);   
            
        }
    }
}