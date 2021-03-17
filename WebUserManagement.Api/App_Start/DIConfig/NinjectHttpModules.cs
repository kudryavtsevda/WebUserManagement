using AutoMapper;
using Ninject.Modules;
using Ninject.Web.Common;
using System.Configuration;
using WebUserManagement.Api.DAL;
using WebUserManagement.Api.DAL.Models;
using WebUserManagement.DTO;
using WebUserManagement.Api.Services;
using System.Data;
using System.Data.SqlClient;

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
                Bind<IDbConnection>().To<SqlConnection>().WithConstructorArgument(_connectionString);
                Bind<IRepository>().To<UserRepository>().InRequestScope();
                Bind<IUserService>().To<UserService>().InRequestScope();
                Bind<IMapper>().ToMethod(x => ConfigureMapping())
                    .InSingletonScope();
            }

            private static Mapper ConfigureMapping()
            {
                return new Mapper(new MapperConfiguration(cgf =>
                {
                    cgf.CreateMap<User, UserResponse>();
                    cgf.CreateMap<CreateUserRequest, User>();
                    cgf.CreateMap<UpdateUserRequest, User>();
                }));
            }
        }
    }
}