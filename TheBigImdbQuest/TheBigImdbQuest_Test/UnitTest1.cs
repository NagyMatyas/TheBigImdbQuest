using NUnit.Framework;

namespace TheBigImdbQuest_Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test_Pass()
        {
            Assert.Pass();
        }

        [Test]
        public void Test_Fail()
        {
            Assert.Fail();
        }
    }
}