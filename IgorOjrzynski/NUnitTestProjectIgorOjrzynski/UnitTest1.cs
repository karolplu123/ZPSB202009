using System;
using NUnit.Framework;
using NUnit.Samples.Cash;

namespace NUnitTestProjectIgorOjrzynski
{
    public class Tests
    {
        private Cash f14CHF;

        [SetUp]
        public void Setup()
        {
            f14CHF = new Cash(14, "CHF");
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

        /// <summary>
        /// Assert that multiplying currency in cach happens correctly
        /// </summary>
        [Test]
        public void SimpleMultiply()
        {
            // [14 CHF] *2 == [28 CHF]
            Cash expected = new Cash(28, "CHF");
            Assert.AreEqual(expected, f14CHF.Multiply(2));
        }
    }
}