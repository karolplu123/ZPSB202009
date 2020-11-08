using NUnit.Framework;
using System;
using NUnit.Samples.Cash;

namespace NUnitTestProject1
{
    public class Tests
    {
        private Cash f14CHF;

        [SetUp]
        public void Setup()
        {
            f14CHF = new Cash(14, "CHF");
            Console.WriteLine("This is setUp");
        }

    
        [TearDown]
        protected void Teardown()
        {
            Console.WriteLine("This is Teardown");
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
        public void xxy()
        {
            var x = 1;
            var y = 1;
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

        [Test]
        public void SimpleAdd()
        {
            // [14 CHF] + [14 CHF] == [28 CHF]
            Cash expected = new Cash(14, "CHF");
            f14CHF.Add(expected);
            Assert.AreEqual(expected, f14CHF);

        }

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        public void SetCurrency_changeCurrenctToCHF_ThreeObjectCurrenciesIsAreEqual(int value)
        {
            Cash c2 = new Cash(value, "CHF");
            Cash c = new Cash(value, "PLN");
            c.SetCurrency("CHF");
            Assert.AreEqual(c2.Currency, c.Currency);
        }
    }
}