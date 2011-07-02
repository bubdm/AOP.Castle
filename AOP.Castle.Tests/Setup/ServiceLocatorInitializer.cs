using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.Windsor;
using Microsoft.Practices.ServiceLocation;
using CommonServiceLocator.WindsorAdapter;
using AOP.Castle;
using AOP.Castle.Tests.Services;
using Castle.MicroKernel.Registration;

namespace AOP.Castle.Tests.Setup
{
    public class ServiceLocatorInitializer
    {
        public static void Init()
        {
            IWindsorContainer container = new WindsorContainer();

            container.AddFacility("AspectAttributeFacility", new AspectFacility());

            container.Register(Component.For<ITestService>().ImplementedBy<TestService>().Named("ITestService"));

            ServiceLocator.SetLocatorProvider(() => new WindsorServiceLocator(container));
        }
    }
}
