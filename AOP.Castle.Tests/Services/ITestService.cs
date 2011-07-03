using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AOP.Castle.Tests.Services
{
    public interface ITestService
    {
        bool Method(string name, int val);
        bool MethodTwoAttributes(string name, int val);
        bool VirtualMethod(string name, int val);
        bool VirtualMethodTwoAttributes(string name, int val);
        bool MethodWithException(string name, int val);
        bool MethodWithoutAttributes(string name, int val);
        bool MethodWithSameAttributeInClassAndMethod(string name, int val);
        bool MethodWithTwoAttributesOneDupFromClassLevel(string name, int val);
        object MethodTwoAttributesOneAbortOnEntry(string name, int val);
    }
}
