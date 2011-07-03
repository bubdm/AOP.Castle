using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AOP.Castle.Tests.Helpers;

namespace AOP.Castle.Tests.Attributes
{
    public class AbortOnEntryAttribute : MethodBoundaryAttribute
    {
        public override void OnEntry(MethodExecutionArgs args)
        {
            args.FlowBehavior = FlowBehavior.Return;
            args.ReturnValue = "abort return value";

            MethodBoundaryTestHelper.EntryCount++;
            Console.WriteLine("AbortOnEntry - Entry");
        }

        public override void OnExit(MethodExecutionArgs args)
        {
            MethodBoundaryTestHelper.Exit++;
            Console.WriteLine("AbortOnEntry - Exit");
        }

        public override void OnException(MethodExecutionArgs args)
        {
            MethodBoundaryTestHelper.Exception++;
            Console.WriteLine("AbortOnEntry - Exception");
        }

        public override void OnSuccess(MethodExecutionArgs args)
        {
            MethodBoundaryTestHelper.SuccessCount++;
            Console.WriteLine("AbortOnEntry - Success");
        }
    }
}
