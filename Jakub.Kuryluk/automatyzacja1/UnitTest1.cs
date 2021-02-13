using NUnit.Framework;
using System;
using NUnit.Samples.Cash;
using Moq;

namespace automatyzacja1
{
    public class Tests
    {
        private Cash f14CHF;

        [SetUp]
        //public void Setup()
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

        /// <summary>
        /// Assert that multiplying currency in Cash happens correctly
        /// </summary>
        [Test]
        public void SimpleMultiply()
        {
            // [14 CHF] *2 == [28 CHF]
            Cash expected = new Cash(28, "CHF");
            Assert.AreEqual(expected, f14CHF.Multiply(2));
        }

        /// <summary>
        /// Assert that negate currency in Cash works correctly
        /// </summary>
        [Test]
        public void SimpleNegate()
        {
            // -[14 CHF] == [-14 CHF]
            Cash expected = new Cash(-14, "CHF");
            Assert.AreEqual(expected, f14CHF.Negate());
        }
        
        /// <summary>
        /// Assert that subtract currency in Cash works correctly
        /// </summary>
        [Test]
        public void SimpleSubtract()
        {
            // [14 CHF] - [5 CHF] == [9 CHF]
            Cash expected = new Cash(9, "CHF");
            Cash subtrahend = new Cash(5, "CHF");
            Assert.AreEqual(expected, f14CHF.Subtract(subtrahend));
        }

        /// <summary>
        /// Assert that ToString currency converts correctly
        /// </summary>
        [Test]
        public void SimpleToString()
        {
            // [14 CHF]
            String expected = "[14 CHF]";
            Assert.AreEqual(expected, f14CHF.ToString());
        }

        /// <summary>
        /// Assert that IsZero works correctly
        /// </summary>
        [Test]
        public void SimpleIsZero()
        {
            // [false]
            Boolean expected = false;
            Assert.AreEqual(expected, f14CHF.IsZero);
        }

        /// <summary>
        /// Assert that Equalsworks correctly
        /// </summary>
        [Test]
        public void SimpleEquals()
        {
            // [14 CHF]
            Cash compare = new Cash(14, "CHF");
            Boolean expected = true;
            Assert.AreEqual(expected, f14CHF.Equals(compare));
        }

        /// <summary>
        /// Assert that Currency works correctly
        /// </summary>
        [Test]
        public void SimpleCurrency()
        {
            // [CHF]
            String currency = "CHF";
            Assert.AreEqual(currency, f14CHF.Currency);
        }

        /// <summary>
        /// Assert that GetHashCode works correctly
        /// </summary>
        [Test]
        public void SimpleGetHashCode()
        {
            // [true]
            int expected = "CHF".GetHashCode()+14;
            Assert.AreEqual(expected, f14CHF.GetHashCode());
        }

        /// <summary>
        /// Assert that SetCurrency works correctly
        /// </summary>
        [Test]
        public void SimpleSetCurrency()
        {
            string expected = "PLN";
            f14CHF.SetCurrency(expected);
            Assert.AreEqual(expected, f14CHF.Currency);
        }

        /// <summary>
        /// Assert that Add works correctly
        /// </summary>
        [Test]
        public void SimpleAdd()
        {
            Cash add = new Cash(10, "CHF");
            Cash expected = new Cash(24, "CHF");
            Assert.AreEqual(expected, f14CHF.Add(add));
        }

        /// <summary>
        /// Assert that AddMoney works correctly
        /// </summary>
        [Test]
        public void SimpleAddMoney()
        {
            Cash add = new Cash(10, "CHF");
            Cash expected = new Cash(24, "CHF");
            Assert.AreEqual(expected, f14CHF.AddMoney(add));
        }

        /// <summary>
        /// Assert that AddMoneyBag works correctly
        /// </summary>
        [Test]
        public void SimpleAddMoneyBag()
        {
            Cash add = new Cash(10, "CHF");
            Cash expected = new Cash(24, "CHF");
            Assert.AreEqual(expected, f14CHF.AddMoneyBag(add));
        }

        /// <summary>
        /// Assert that Amount works correctly
        /// </summary>
        [Test]
        public void SimpleAmount()
        {
            int expected = 14;
            Assert.AreEqual(expected, f14CHF.Amount);
        }

        /// <summary>
        /// Test set Currency , Data-Driven Testing
        /// </summary>
        [TestCase(1, "PLN")]
        [TestCase(2, "EUR")]
        [TestCase(3, "PLZ")]
        public void SetNewCash_ChangeCurrencyToCHF_TwoObjectsAreEqual(int amount, string currency)
        {
            // arrange
            Cash expected = new Cash(amount, "CHF");
            Cash tested = new Cash(amount, currency);

            // act
            tested.SetCurrency("CHF");

            // assert
            Assert.AreEqual(expected.Currency, tested.Currency);
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
            mockBag.Verify(mock => mock.AddMoney(It.IsAny<Cash>()), Times.Once());
        }
    }
}