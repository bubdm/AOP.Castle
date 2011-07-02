using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using AOP.Castle.Tests.Setup;

namespace AOP.Castle.Tests
{
    [SetUpFixture]
    public class AssemblySetup
    {
        [SetUp]
        public void Setup()
        {
            ServiceLocatorInitializer.Init();
        }
    }
}
