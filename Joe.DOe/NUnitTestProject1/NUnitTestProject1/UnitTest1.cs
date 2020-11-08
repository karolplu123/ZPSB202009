using NUnit.Samples.Cash;
using NUnit.Framework;
using System;

namespace NUnitTestProject1
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

        [TearDown]
        public void Teardown()
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

        ///<summary>
        //////Assert that multiplying currency in Cash happens correctly
        //////</summary>
        //////
        [Test]
        public void SimpleMultiply()
        {
            // [14 CHF] *2 == [28 CHF]
            Cash expected = new Cash(28, "CHF");
            Assert.AreEqual(expected, f14CHF.Multiply(2));
        }

        ///<summary>
        ///Test set Currency, Data-Driven Testing
        ///</summary>
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        public void SetCurrency_ChangeCurrencyToCHF_TwoObjectCurrenciesAreEqual(int amount)
        { 
            // arrange
            Cash c2 = new Cash(amount, "CHF");
            Cash c = new Cash(amount, "PLN");

            //act
            c.SetCurrency("CHF");

            //assert
            Assert.AreEqual(c2.Currency, c.Currency);
        }

    }
}