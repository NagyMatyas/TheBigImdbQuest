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
        [TestCase(2456123, 1258369, 1.1)]
        public void GivenAmountOfDevationIsReceived_ExpectToCalculateScorePenalty(int maxNrOfReviews, int actualNrOfReviews, double penalty)
        {
            Assert.AreEqual(penalty, penalizer.GetReviewPenalty(maxNrOfReviews, actualNrOfReviews));
        }
    }
}