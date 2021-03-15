using Ninject.Modules;
using Ninject.Web.Common;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using WebUserManagement.Api.DAL;
using WebUserManagement.Api.Services;


namespace WebUserManagement.Api.App_Start
{/*
    public class DependencyInjectionModule : NinjectModule
    {
        private readonly string _connectionString;

        public DependencyInjectionModule()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["DbConnection"].ToString();
        }

        public DependencyInjectionModule(string connectionString)
        {
            _connectionString = connectionString;
        }

        public override void Load()
        {              
            Bind<ApplicationContext>().ToSelf().InRequestScope().WithConstructorArgument(_connectionString);
            Bind<IUserService>().To<UserService>().InRequestScope();
        }
    }*/
}