using NUnit.Framework;
using System;
using NUnit.Samples.Cash;
using Moq;

namespace NUnitTestProject1
{
    public class Tests
    {
        private Cash f14CHF;

        [SetUp]
        protected void SetUp()
        {
            f14CHF = new Cash(14, "CHF");

            Console.WriteLine("This is SetUp");
        }

        [TearDown]
        protected void Teardown()
        {
            Console.WriteLine("This is Teardown");
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


        [Test]
        [Category("Smoke")]
        public void testAreEqual()
        {
            var x = 1;
            var y = 1;
            Assert.AreEqual(x, y);
        }

        [Test]
        [Category("Sanity")]
        public void testAreNotEqual()
        {
            var x = 1;
            var y = 2;
            Assert.AreNotEqual(x, y);
        }

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        public void SetCurrency_ChangeCurrencyToCHF_TwoCashCurrenciesAreEqual(int value)
        {
            Cash c = new Cash(value, "PLN");
            Cash c2 = new Cash(value, "CHF");

            c.SetCurrency("CHF");

            Assert.AreEqual(c.Currency, c2.Currency);
        }

        [Test]
        [Category("Unit")]
        public void TestMock()
        {
            //assert
            var Cash = new Cash(2, "PLN");
            var mockBag = new Mock<ICash>();
            mockBag.Setup(x => x.AddMoney(It.IsAny<Cash>())).Returns(new
                Cash(1, "CHF"));
            //act
            Cash.AddMoneyBag(mockBag.Object);
            //assert
            Assert.IsTrue(true);
            mockBag.Verify(mock => mock.AddMoney(It.IsAny<Cash>()), Times.Never());
        }

    }
}