using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AOP.Castle.Tests.Attributes;

namespace AOP.Castle.Tests.Services
{
    [Test3(Level = "Class")]
    public class TestService : ITestService
    {
        [Test1]
        public bool Method(string name, int val)
        {
            return true;
        }

        [Test1]
        [Test2]
        public bool MethodTwoAttributes(string name, int val)
        {
            return true;
        }

        [Test1]
        public bool VirtualMethod(string name, int val)
        {
            return true;
        }

        [Test1, Test2]
        public bool VirtualMethodTwoAttributes(string name, int val)
        {
            return true;
        }

        [Test2]
        public bool MethodWithException(string name, int val)
        {
            throw new Exception("MyException");
        }

        public bool MethodWithoutAttributes(string name, int val)
        {
            return true;
        }

        [Test3(Level = "Method")]
        public bool MethodWithSameAttributeInClassAndMethod(string name, int val)
        {
            return true;
        }

        [Test1]
        [Test3(Level = "Method")]
        public bool MethodWithTwoAttributesOneDupFromClassLevel(string name, int val)
        {
            return true;
        }
    }
}
