using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
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