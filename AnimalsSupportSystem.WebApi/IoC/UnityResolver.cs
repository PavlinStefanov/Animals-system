using System;
using System.Collections.Generic;
using Unity;
using Unity.Exceptions;
using System.Web.Http.Dependencies;

namespace AnimalsSupportSystem.WebApi.IoC
{
    public class UnityResolver : IDependencyResolver
    {
        protected IUnityContainer _container;

        public UnityResolver(IUnityContainer container)
        {
            _container = container ?? throw new ArgumentNullException("container");
        }

        public object GetService(Type serviceType)
        {
            try
            {
                return _container.Resolve(serviceType);
            }
            catch (ResolutionFailedException)
            {
                return null;
            }
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            try
            {
                return _container.ResolveAll(serviceType);
            }
            catch (ResolutionFailedException)
            {
                return new List<object>();
            }
        }

        public IDependencyScope BeginScope()
        {
            var child = _container.CreateChildContainer();
            return new UnityResolver(child);
        }

        public void Dispose()
        {
            Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            _container.Dispose();
        }
    }
}