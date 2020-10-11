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
        public void Test1()
        {
            Assert.Pass();
        }

        [Test]
        [Category("Sanity")]
        public void Test2()
        {
            var x = 1;
            var y = 2;
            Assert.AreEqual(x, y);
        }

        [TearDown]
        public void Teardown() {
            Console.WriteLine("This is TearDown");
        }
    }
}