using System;
using System.Collections.Generic;
using Castle.Core.Interceptor;
using Castle.MicroKernel.Facilities;
using Castle.MicroKernel;
using Castle.Core;
using System.Reflection;
using Castle.DynamicProxy;
using Castle.MicroKernel.Registration;


namespace AOP.Castle
{
    public class AspectFacility : AbstractFacility
    {
        protected override void Init()
        {
            Kernel.Register(Component.For<IInterceptor>()
                                     .ImplementedBy<MethodBoundaryInterceptor>()
                                     .Named(typeof(MethodBoundaryInterceptor).Name)
                                     .LifeStyle.Is(LifestyleType.Singleton));
            Kernel.ComponentRegistered += KernelComponentRegistered;
        }

        private void KernelComponentRegistered(string key, IHandler handler)
        {
            AddMethodBoundaryInterceptorIfNeeded(handler);
        }

        #region MethodBoundaryInterceptor
        private void AddMethodBoundaryInterceptorIfNeeded(IHandler handler)
        {
            List<Attribute> attributes = GetMethodBoundaryAttributes(handler);

            if (attributes.Count > 0)
            {
                handler.ComponentModel.Interceptors.Add(new InterceptorReference(typeof(MethodBoundaryInterceptor).Name));
            }
        }

        private List<Attribute> GetMethodBoundaryAttributes(IHandler handler)
        {
            var attributes = new List<Attribute>();
            
            //mthod level attributes
            foreach (MethodInfo methodInfo in handler.ComponentModel.Implementation.GetMethods())
            {
                attributes.AddRange((Attribute[])methodInfo.GetCustomAttributes(typeof(MethodBoundaryAttribute), false));
            }

            //class level attributes
            attributes.AddRange((Attribute[])handler.ComponentModel.Implementation.GetCustomAttributes(typeof(MethodBoundaryAttribute), false));

            return attributes;
        }
        #endregion
    }
}
