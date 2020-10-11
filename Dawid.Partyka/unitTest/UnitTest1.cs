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

        [TearDown]
        public void Teardown() {
            Console.WriteLine("This is TearDown");
        }

        [Category("Smoke")]
        [Test]
        public void xxx()
        {
            var x = 1;
            var y = 2;
            Assert.AreEqual(x, y);
        }
    }
}