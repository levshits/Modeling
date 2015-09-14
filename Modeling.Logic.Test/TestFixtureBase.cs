using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Spring.Context.Support;
using Spring.Testing.NUnit;

namespace Modeling.Logic.Test
{
    [TestClass]
    public class TestFixtureBase: AbstractDependencyInjectionSpringContextTests
    {
        [SetUp]
        public void SetupContext()
        {

        }

        [TearDown]
        public void TearDownContext()
        {

        }

        protected override string[] ConfigLocations
        {
            get
            {
                return new[]
                    {
                        @"Configs\test.xml"
                    };
            }
        }
    }
}
