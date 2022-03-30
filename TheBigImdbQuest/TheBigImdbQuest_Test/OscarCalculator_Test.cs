using NUnit.Framework;
using TheBigImdbQuest;

namespace TheBigImdbQuest_Test
{
    public class OscarCalculator_Tests
    {
        [Test]
        [TestCase( 0, 0.0)]
        [TestCase( 1, 0.3)]
        [TestCase( 2, 0.3)]
        [TestCase( 3, 0.5)]
        [TestCase( 4, 0.5)]
        [TestCase( 5, 0.5)]
        [TestCase( 6, 1.0)]
        [TestCase( 7, 1.0)]
        [TestCase( 8, 1.0)]
        [TestCase( 9, 1.0)]
        [TestCase(10, 1.0)]
        [TestCase(11, 1.5)]
        [TestCase(99, 1.5)]
        public void GivenNumberOfOscarsHasBeenWon_ExpectToReturnTheRewardPoint(int nrOfOscars, double reward)
        {
            Assert.AreEqual(reward, OscarCalculator.GetOscarRewards(nrOfOscars));
        }
    }
}