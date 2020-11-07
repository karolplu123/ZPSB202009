using System;
using NUnit.Framework;

namespace NUnitTestProjectIgorOjrzynski
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            Console.WriteLine("This is Setup in CLI");
        }

        [TearDown]
        protected void Teardown()
        {
            Console.WriteLine("This is Teardown in CLI");
        }

        [Category("Smoke")]
        [Test]
        public void Test1()
        {
            var x = 1;
            var y = 2;

            Assert.AreEqual(x, y);
        }

        [Category("Sanity")]
        [Test]
        public void Test2()
        {
            var x = 1;
            var y = 2;

            Assert.AreEqual(x, y);
        }
    }
}