using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AOP.Castle.Tests.Helpers
{
    public static class MethodBoundaryTestHelper
    {
        public static int EntryCount { get; set; }
        public static int SuccessCount { get; set; }
        public static int Exit { get; set; }
        public static int Exception { get; set; }

        public static void Reset()
        {
            EntryCount = 0;
            SuccessCount = 0;
            Exit = 0;
            Exception = 0;
        }
    }
}
