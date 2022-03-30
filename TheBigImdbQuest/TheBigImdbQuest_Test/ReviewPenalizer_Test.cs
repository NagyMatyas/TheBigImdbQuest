using NUnit.Framework;
using TheBigImdbQuest;

namespace TheBigImdbQuest_Test
{
    public class ReviewPenalizer_Test
    {
        const double Deviation = 100000;
        const double Deduction = 0.1;
        ReviewPenalizer penalizer;

        [SetUp]
        public void Setup()
        {
            penalizer = new ReviewPenalizer(Deviation, Deduction);
        }

        [Test]
        [TestCase(2456123, 1258369                          , 1.1)]
        [TestCase(1234567, 1234567 - (int)Deviation + 1     , Deduction * 0)]
        [TestCase(1234567, 1234567 - (int)Deviation         , Deduction * 1)]
        [TestCase(7654321, 7654321 - (int)Deviation * 2 + 1 , Deduction * 1)]
        [TestCase(7654321, 7654321 - (int)Deviation * 2     , Deduction * 2)]

        public void GivenAmountOfDevationIsReceived_ExpectToCalculateScorePenalty(int maxNrOfReviews, int actualNrOfReviews, double penalty)
        {
            Assert.AreEqual(penalty, penalizer.GetReviewPenalty(maxNrOfReviews, actualNrOfReviews));
        }
    }
}