using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using AOP.Castle.Tests.Services;
using Microsoft.Practices.ServiceLocation;
using AOP.Castle.Tests.Helpers;

namespace AOP.Castle.Tests
{
    [TestFixture]
    public class MethodBoundaryAspectTests
    {
        [Test]
        public void Method()
        {
            ITestService productService = ServiceLocator.Current.GetInstance<ITestService>();
            MethodBoundaryTestHelper.Reset();

            bool ret = productService.Method("Dan", 5);

            Assert.AreEqual(2, MethodBoundaryTestHelper.EntryCount);
            Assert.AreEqual(2, MethodBoundaryTestHelper.SuccessCount);
            Assert.AreEqual(2, MethodBoundaryTestHelper.Exit);
            Assert.AreEqual(0, MethodBoundaryTestHelper.Exception);
        }

        [Test]
        public void Method_two_attributes()
        {
            ITestService productService = ServiceLocator.Current.GetInstance<ITestService>();
            MethodBoundaryTestHelper.Reset();

            bool ret = productService.MethodTwoAttributes("Dan", 5);

            Assert.AreEqual(3, MethodBoundaryTestHelper.EntryCount);
            Assert.AreEqual(3, MethodBoundaryTestHelper.SuccessCount);
            Assert.AreEqual(3, MethodBoundaryTestHelper.Exit);
            Assert.AreEqual(0, MethodBoundaryTestHelper.Exception);
        }

        [Test]
        public void Virtual_method()
        {
            ITestService productService = ServiceLocator.Current.GetInstance<ITestService>();
            MethodBoundaryTestHelper.Reset();

            bool ret = productService.VirtualMethod("Dan", 5);

            Assert.AreEqual(2, MethodBoundaryTestHelper.EntryCount);
            Assert.AreEqual(2, MethodBoundaryTestHelper.SuccessCount);
            Assert.AreEqual(2, MethodBoundaryTestHelper.Exit);
            Assert.AreEqual(0, MethodBoundaryTestHelper.Exception);
        }

        [Test]
        public void Virtual_method_two_attributes()
        {
            ITestService productService = ServiceLocator.Current.GetInstance<ITestService>();
            MethodBoundaryTestHelper.Reset();

            bool ret = productService.VirtualMethodTwoAttributes("Dan", 5);

            Assert.AreEqual(3, MethodBoundaryTestHelper.EntryCount);
            Assert.AreEqual(3, MethodBoundaryTestHelper.SuccessCount);
            Assert.AreEqual(3, MethodBoundaryTestHelper.Exit);
            Assert.AreEqual(0, MethodBoundaryTestHelper.Exception);
        }

        [Test]
        public void Method_throw_exception()
        {
            ITestService productService = ServiceLocator.Current.GetInstance<ITestService>();
            MethodBoundaryTestHelper.Reset();

            try
            {
                bool ret = productService.MethodWithException("Dan", 5);
                Assert.Fail();
            }
            catch (Exception exp)
            {
                Assert.AreEqual(2, MethodBoundaryTestHelper.EntryCount);
                Assert.AreEqual(0, MethodBoundaryTestHelper.SuccessCount);
                Assert.AreEqual(2, MethodBoundaryTestHelper.Exit);
                Assert.AreEqual(2, MethodBoundaryTestHelper.Exception);
                Assert.AreEqual("MyException", exp.Message);
            }
        }

        [Test]
        public void Method_without_attributes()
        {
            ITestService productService = ServiceLocator.Current.GetInstance<ITestService>();
            MethodBoundaryTestHelper.Reset();

            bool ret = productService.MethodWithoutAttributes("Dan", 5);

            Assert.AreEqual(1, MethodBoundaryTestHelper.EntryCount);
            Assert.AreEqual(1, MethodBoundaryTestHelper.SuccessCount);
            Assert.AreEqual(1, MethodBoundaryTestHelper.Exit);
            Assert.AreEqual(0, MethodBoundaryTestHelper.Exception);
        }

        [Test]
        public void Method_with_same_attribute_in_class_and_metho()
        {
            ITestService productService = ServiceLocator.Current.GetInstance<ITestService>();
            MethodBoundaryTestHelper.Reset();

            bool ret = productService.MethodWithSameAttributeInClassAndMethod("Dan", 5);

            Assert.AreEqual(1, MethodBoundaryTestHelper.EntryCount);
            Assert.AreEqual(1, MethodBoundaryTestHelper.SuccessCount);
            Assert.AreEqual(1, MethodBoundaryTestHelper.Exit);
            Assert.AreEqual(0, MethodBoundaryTestHelper.Exception);
        }
        
        [Test]
        public void  Method_with_two_attributes_one_dup_from_class_level()
        {
            ITestService productService = ServiceLocator.Current.GetInstance<ITestService>();
            MethodBoundaryTestHelper.Reset();

            bool ret = productService.MethodWithTwoAttributesOneDupFromClassLevel("Dan", 5);

            Assert.AreEqual(2, MethodBoundaryTestHelper.EntryCount);
            Assert.AreEqual(2, MethodBoundaryTestHelper.SuccessCount);
            Assert.AreEqual(2, MethodBoundaryTestHelper.Exit);
            Assert.AreEqual(0, MethodBoundaryTestHelper.Exception);
        }
    }
}
