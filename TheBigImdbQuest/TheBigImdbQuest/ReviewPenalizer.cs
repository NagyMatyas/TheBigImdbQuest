using System;

namespace TheBigImdbQuest
{
    public class ReviewPenalizer
    {
        private readonly double penaltyRate;

        public ReviewPenalizer(double deviation, double deduction)
        {
            this.penaltyRate = deviation / deduction;
        }

        public double GetReviewPenalty(int maxNrOfReviews, int actualNrOfReviews)
        {
            return Math.Floor((maxNrOfReviews - actualNrOfReviews) / penaltyRate * 10) / 10;
        }
    }
}
