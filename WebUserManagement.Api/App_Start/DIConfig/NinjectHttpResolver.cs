using Ninject;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Web.Http.Dependencies;

namespace WebUserManagement.Api.App_Start.DIConfig
{
    public class NinjectHttpResolver : IDependencyResolver, IDependencyScope
    {
        public IKernel Kernel { get; private set; }
        public NinjectHttpResolver(params NinjectModule[] modules)
        {
            Kernel = new StandardKernel(modules);
        }

        public NinjectHttpResolver(Assembly assembly)
        {
            Kernel = new StandardKernel();
            Kernel.Load(assembly);
        }

        public object GetService(Type serviceType)
        {
            return Kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return Kernel.GetAll(serviceType);
        }

        public void Dispose()
        {
            
        }

        public IDependencyScope BeginScope()
        {
            return this;
        }
    }

}