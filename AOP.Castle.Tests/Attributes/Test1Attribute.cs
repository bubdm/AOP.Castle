using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AOP.Castle.Tests.Helpers;

namespace AOP.Castle.Tests.Attributes
{
    public class Test1Attribute : MethodBoundaryAttribute
    {
        public override void OnEntry()
        {
            MethodBoundaryTestHelper.EntryCount++;
            Console.WriteLine("Test 1 - Entry");
        }

        public override void OnExit()
        {
            MethodBoundaryTestHelper.Exit++;
            Console.WriteLine("Test 1 - Exit");
        }

        public override void OnException(Exception exception)
        {
            MethodBoundaryTestHelper.Exception++;
            Console.WriteLine("Test 1 - Exception");
        }

        public override void OnSuccess()
        {
            MethodBoundaryTestHelper.SuccessCount++;
            Console.WriteLine("Test 1 - Success");
        }
    }
}
