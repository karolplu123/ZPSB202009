using NUnit.Framework;
using System;
using NUnit.Samples.Cash;

namespace unitTest
{
    public class Tests
    {
        private Cash f14CHF;

        [SetUp]
        public void Setup()
        {
            f14CHF = new Cash(14, "CHF");

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

        /// <summary>
        /// Assert that multiplying currency in Cash happens correctly
        /// </summary>
        ///
        [Test]
        public void SimpleMultiply()
        {
            // [14 CHF] *2 == [28 CHF]
            Cash expected = new Cash(28, "CHF");
            Assert.AreEqual(expected, f14CHF.Multiply(2));
        }

        [TearDown]
        public void Teardown() {
            Console.WriteLine("This is TearDown");
        }
    }
}