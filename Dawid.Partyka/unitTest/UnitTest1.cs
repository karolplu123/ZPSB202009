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

        [Test]
        public void SimpleAdd()
        {
            // [14 CHF] + [14 CHF] - [14 CHF] == [14 CHF]
            Cash expected = new Cash(14, "CHF");
            f14CHF.Add(expected);
            f14CHF.Subtract(expected);

            Assert.AreEqual(expected, f14CHF);
        }

        [Test]
        public void AddMoneyTest()
        {
            Cash add = new Cash(5, "USD");
            CashBag reference = new CashBag(add, f14CHF);

            Assert.AreEqual(reference, f14CHF.AddMoney(add));
        }

        [Test]
        public void EqualsMethodWithNotHandledObject()
        {
            CashBag notHandledObject = new CashBag(new Cash(5, "USD"), f14CHF);

            Assert.AreEqual(false, f14CHF.Equals(notHandledObject));
        }

        [Test]
        public void isZeroAndNegateCheck()
        {
            Cash expected = new Cash(0, "CHF");
            Assert.AreEqual(expected, f14CHF.Add(f14CHF.Negate()));
        }

        [Test]
        public void MoneyBagTest()
        {
            Cash start = new Cash(6, "CHF");
            Cash add = new Cash(5, "PLN");
            CashBag test = new CashBag(start, add);
            
            Assert.AreEqual(start.AddMoneyBag(test), test.Multiply(2).Subtract(add));
        }

        /// <summary>
        /// Test set Currency , Data-Driven Testing
        /// </summary>
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        public void SetCurrency_ChangeCurrencyToCHF_TwoObjectCurrenciesAreEqual(int amount)
        {
            // arrange
            Cash c2 = new Cash(amount, "CHF");
            Cash c = new Cash(amount, "PLN");

            // act
            c.SetCurrency("CHF");

            // assert
            Assert.AreEqual(c2.Currency, c.Currency);
        }

        /// <summary>
        ///  TDD Cash_class.ToString() test
        /// </summary>

        [TestCase(14, "CHF")]
        [TestCase(15, "PLN")]
        [TestCase(0, "CAD")]
        public void ToString_GetStringOfClassCash_ReceivedStringIsCorrect(int amount, string currency)
        {
            // arrange
            Cash test = new Cash(amount, currency);

            // act
            string toTest = test.ToString();

            // assert
            Assert.AreEqual($"[{amount} {currency}]", toTest);
        }

        [Test]
        public void Hashes()
        {
            Cash chf = new Cash(6, "CHF");
            Cash chf2 = new Cash(3, "CHF");

            Assert.AreEqual(chf.GetHashCode(), chf2.Multiply(2).GetHashCode());
        }

        [Test]
        public void CashBagNegate()
        {
            CashBag test = new CashBag(new Cash(1, "CAD"), new Cash(1, "PLN"));
            test = (CashBag)test.Negate();

            Assert.AreEqual(new CashBag(new Cash(-1, "PLN"), new Cash(-1, "CAD")), test);
        }

        [Test]
        public void CashBagAppend()
        {
            Cash chf1 = new Cash(6, "CHF");
            Cash chf2 = (Cash)chf1.Negate();
            Cash cad = new Cash(1, "CAD");
            Cash usd = new Cash(7, "USD");

            CashBag test = new CashBag(new CashBag(chf1, cad), new CashBag(chf2, usd));
            CashBag compare = new CashBag(cad, usd);

            Assert.AreEqual(test, compare);
        }

        [TearDown]
        public void Teardown() {
            Console.WriteLine("This is TearDown");
        }
    }
}
