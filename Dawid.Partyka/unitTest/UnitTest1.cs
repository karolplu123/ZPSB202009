using NUnit.Framework;

namespace unitTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            console.log("This is SetUp");
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }

        [TearDown]
        public void Teardown() { }
    }
}