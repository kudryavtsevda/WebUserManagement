using AutoMapper;
using Ninject.Modules;
using Ninject.Web.Common;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using WebUserManagement.Api.DAL;
using WebUserManagement.Api.DAL.Models;
using WebUserManagement.Api.DTO;
using WebUserManagement.Api.Services;

namespace WebUserManagement.Api.App_Start.DIConfig
{
    public class NinjectHttpModules
    {        
        public static NinjectModule[] Modules
        {
            get
            {
                return new[] { new MainModule() };
            }
        }
        
        public class MainModule : NinjectModule
        {
            private readonly string _connectionString;

            public MainModule()
            {
                _connectionString = ConfigurationManager.ConnectionStrings["DbConnection"].ToString();
            }

            public MainModule(string connectionString)
            {
                _connectionString = connectionString;
            }

            public override void Load()
            {
                Bind<ApplicationContext>().ToSelf().InRequestScope().WithConstructorArgument(_connectionString);
                Bind<IUserService>().To<UserService>().InRequestScope();
                Bind<IMapper>().ToConstructor(_ => new Mapper(new MapperConfiguration(cgf => cgf.CreateMap<User, UserResponse>())))
                    .InSingletonScope();
            }
        }
    }
}