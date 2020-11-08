using NUnit.Framework;
using System;
using NUnit.Samples.Cash;


namespace NUnitTestProject1
{

    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            Console.WriteLine("This is SetUp");
        }

        [TearDown]
        public void Teardown()
        {
            Console.WriteLine("This is TearDown");
        }
       
        [Category("Smoke")]
        [Test]
        public void xxx()
        {
            var x = 1;
            var y = 2;
            Assert.AreEqual(x, y);
        }

        [Category("None")]
        [Test]
        public void abc()
        {
            var x = 3;
            var y = 3;
            Assert.AreEqual(x, y);
        }


        
        
        /// <summary>
        /// Test set Currency , Data-Driven Testing.
        /// </summary>
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        public void TDDCheck(int value)
        {
            if (value == 3)
            {
                Assert.Fail();
            }
            var curr = "CHF";
            Cash c2 = new Cash(value, "CHF");
            Cash c = new Cash(value, "PLN");
            c.SetCurrency("CHF");
            Assert.AreEqual(c2.Currency, c.Currency);
        }

        public void TestCheckCurrency(int value)
        {
            Cash c = new Cash(value, "CHF");
            Cash c2 = new Cash(value, "PLN");

            c.SetCurrency("PLN");

            Assert.AreEqual(c2.Currency, c.Currency);

        }


        
    }






}