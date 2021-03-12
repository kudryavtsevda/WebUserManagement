using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebUserManagement.Api.DAL;
using WebUserManagement.Api.Services;


namespace WebUserManagement.Api.App_Start
{
    public class DependencyInjectionModule : NinjectModule
    {
        private readonly string _connectionString;

        public DependencyInjectionModule(string connectionString)
        {
            _connectionString = connectionString;
        }

        public override void Load()
        {
            Bind<IUserService>().To<UserService>();
            Bind<ApplicationContext>().ToSelf().WithConstructorArgument(_connectionString);
        }
    }
}