using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.Windsor;
using AOP.Castle;
using Castle.MicroKernel.Registration;

namespace SimpleApp
{
    public class MyCustomAttribute : MethodBoundaryAttribute
    {
        public override void OnEntry(MethodExecutionArgs args)
        {
            Console.WriteLine("Entry");
        }

        public override void OnExit(MethodExecutionArgs args)
        {
            Console.WriteLine("Exit");
        }

        public override void OnException(MethodExecutionArgs args)
        {
            Console.WriteLine("Exception");
        }

        public override void OnSuccess(MethodExecutionArgs args)
        {
            Console.WriteLine("Success");
        }
    }

    public interface IMyService
    {
        void Foo();
    }

    public class MyService : IMyService
    {
        [MyCustomAttribute]
        public void Foo()
        {
            Console.WriteLine("Method body");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            IWindsorContainer container = new WindsorContainer();
            container.AddFacility("AspectAttributeFacility", new AspectFacility());
            container.Register(Component.For<IMyService>().ImplementedBy<MyService>().Named("MyService"));

            var myService = container.Resolve<IMyService>();
            myService.Foo();

            Console.ReadLine();
        }
    }
}
