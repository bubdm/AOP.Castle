using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AOP.Castle.Tests.Helpers;

namespace AOP.Castle.Tests.Attributes
{
    public class Test3Attribute : MethodBoundaryAttribute
    {
        public string Level { get; set; }

        public override void OnEntry()
        {
            MethodBoundaryTestHelper.EntryCount++;
            Console.WriteLine("Test 3 - Entry - " + Level);
        }

        public override void OnExit()
        {
            MethodBoundaryTestHelper.Exit++;
            Console.WriteLine("Test 3 - Exit - " + Level);
        }

        public override void OnException(Exception exception)
        {
            MethodBoundaryTestHelper.Exception++;
            Console.WriteLine("Test 3 - Exception - " + Level);
        }

        public override void OnSuccess()
        {
            MethodBoundaryTestHelper.SuccessCount++;
            Console.WriteLine("Test 3 - Success - " + Level);
        }
    }
}
