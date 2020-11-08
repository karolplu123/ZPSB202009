using NUnit.Framework;
using NUnit.Samples.Cash;
using System;

namespace NUnitTestProject1
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
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
        [Category("Smoke")]
        [Test]
        public void xxx()
        {
            var x = 1;
            var y = 2;
            Assert.AreEqual(x, y);
        }
        [Category("Smoke")]
        [Test]
        public void xxy()
        {
            var x = 1;
            var y = 1;
            Assert.AreEqual(x, y);
        }

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        public void ChangeSetCurrency_changeCurrenctToCHF_ThreeObjectCurrenciesIsAreEqualeCurrency(int value)
        {
            Cash c = new Cash(value, "PLN");
            Cash c2 = new Cash(value, "CHF");

            c.SetCurrency("CHF");

            Assert.AreEqual(c.Currency, c2.Currency);
        }
    }
}