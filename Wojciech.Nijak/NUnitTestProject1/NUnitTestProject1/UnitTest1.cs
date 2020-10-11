using NUnit.Framework;
using System;

namespace NUnitTestProject1
{
    public class Tests
    {
        [SetUp]
        protected void SetUp()
        {
            Console.WriteLine("This is SetUp");
        }

        [TearDown]
        protected void Teardown()
        {
            Console.WriteLine("This is Teardown");
        }

        [Test]
        [Category("Smoke")]
        public void testAreEqual()
        {
            var x = 1;
            var y = 1;
            Assert.AreEqual(x, y);
        }

        [Test]
        [Category("Sanity")]
        public void testAreNotEqual()
        {
            var x = 1;
            var y = 2;
            Assert.AreNotEqual(x, y);
        }
    }
}