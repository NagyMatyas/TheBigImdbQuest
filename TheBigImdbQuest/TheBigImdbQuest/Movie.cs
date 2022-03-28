using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheBigImdbQuest
{
    public class Movie
    {
        public Movie(string title, double originalRating, double recalculatedRating, int nrOfRatings, int nrOfOscars)
        {
            Title = title;
            OriginalRating = originalRating;
            RecalculatedRating = recalculatedRating;
            NrOfRatings = nrOfRatings;
            NrOfOscars = nrOfOscars;
        }

        public string Title { get; }
        public double OriginalRating { get; }
        public double RecalculatedRating { get; }
        public int NrOfRatings { get; }
        public int NrOfOscars { get; }
    }
}
