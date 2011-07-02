using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AOP.Castle.Tests.Helpers;

namespace AOP.Castle.Tests.Attributes
{
    public class Test2Attribute : MethodBoundaryAttribute
    {
        public override void OnEntry()
        {
            MethodBoundaryTestHelper.EntryCount++;
            Console.WriteLine("Test 2 - Entry");
        }

        public override void OnExit()
        {
            MethodBoundaryTestHelper.Exit++;
            Console.WriteLine("Test 2 - Exit");
        }

        public override void OnException(Exception exception)
        {
            MethodBoundaryTestHelper.Exception++;
            Console.WriteLine("Test 2 - Exception");
        }

        public override void OnSuccess()
        {
            MethodBoundaryTestHelper.SuccessCount++;
            Console.WriteLine("Test 2 - Success");
        }
    }
}
