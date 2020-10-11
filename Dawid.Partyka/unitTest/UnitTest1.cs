using NUnit.Framework;
using System;

namespace unitTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            Console.WriteLine("This is SetUp");
        }

        [Test]
        [Category("Smoke")]
        public void xxx()
        {
            var x = 1;
            var y = 2;
            Assert.AreEqual(x, y);
        }

        [Test]
        [Category("Smoke")]
        public void xx()
        {
            var x = 3;
            var y = 3;
            Assert.AreEqual(x, y);
        }

        [TearDown]
        public void Teardown() {
            Console.WriteLine("This is TearDown");
        }
    }
}