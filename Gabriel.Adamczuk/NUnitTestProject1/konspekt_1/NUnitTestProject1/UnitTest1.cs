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
            Console.WriteLine("This is SetUp");

            f14CHF = new Cash(14, "CHF");
        }
        [TearDown]
        protected void Teardown()
        {
            Console.WriteLine("This is Teardown");
        }

        [Test]
        [Category("Smoke")]
        public void testFirst()
        {
            var x = 2;
            var y = 3;
            Assert.AreEqual(x, y);
        }

        [Test]
        [Category("Sanity")]
        public void testScnd()
        {
            var x = 1;
            var y = 2;
            Assert.AreEqual(x, y);
        }

        [Test]
        [Category("Smoke")]
        public void testThir()
        {
            var x = 1;
            var y = 2;
            Assert.AreNotEqual(x, y);
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
        public void SimpleAdd()
        {
            // [14 CHF] + [14 CHF] == [28 CHF]
            Cash expected = new Cash(14, "CHF");
            f14CHF.Add(expected);
            Assert.AreEqual(expected, f14CHF);

        }

        /// <summary>
        /// Test set Currency , Data-Driven Testing
        /// </summary>
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]

        public void SetCurrency_changeCurrenctToEUR_ThreeObjectCurrenciesIsAreEqual(int value)
        {
            //arr
            Cash c2 = new Cash(value, "EUR");
            Cash c = new Cash(value, "PLN");

            //act
            c.SetCurrency("EUR");

            //assrt
            Assert.AreEqual(c2.Currency, c.Currency);
        }
        [Test]
        public void IsNullAndNegate()
        {
            Cash expected = new Cash(0, "EUR");
            Assert.AreEqual(expected, f14CHF.Add(f14CHF.Negate()));
        }
        [Test]
        [Category("Unit")]
        public void TestMock()
        {
            //assert
            var Cash = new Cash(2, "PLN");
            var mockBag = new Mock<ICash>();
            mockBag.Setup(x => x.AddMoney(It.IsAny<Cash>())).Returns(new Cash(1, "CHF"));
            //act
            Cash.AddMoneyBag(mockBag.Object);
            //assert
            Assert.IsTrue(true);
            mockBag.Verify(mock => mock.AddMoney(It.IsAny<Cash>()), Times.Never());
        }
        [Test]
        public static void MoneyBagTest()
         {
            Cash start = new Cash(4, "CHF");
            Cash add = new Cash(3, "PLN");
            CashBag test = new CashBag(start, add);
            Assert.AreEqual(start.AddMoneyBag(test), test.Multiply(2).Subtract(add));
         }

        }



 }
