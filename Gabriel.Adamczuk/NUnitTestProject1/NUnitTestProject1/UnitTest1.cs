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
        public void testFirst()
        {
            var x = 2;
            var y = 3;
            Assert.AreEqual(x, y);
        }

        [Test]
        [Category("Sanity")]
        public void testScnd()
        {
            var x = 1;
            var y = 2;
            Assert.AreEqual(x, y);
        }

        [Test]
        [Category("Smoke")]
        public void testThir()
        {
            var x = 1;
            var y = 2;
            Assert.AreNotEqual(x, y);
        }
    }
}