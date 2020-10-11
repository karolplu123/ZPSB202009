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

        [Test]
        public void Test1()
        {
            var x = 1;
            var y = 2;
            Assert.IsTrue(y - x == x);
            Assert.AreEqual(x, y);
            
        }



        [TearDown]
        protected void Teardown()
        {
            Console.WriteLine("This is Teardown");
        }
    }
}