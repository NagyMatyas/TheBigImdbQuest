using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheBigImdbQuest
{
    public class Movie
    {
        public string Title { get; }
        public double OriginalRating { get; }
        public double RecalculatedRating { get; }
        public int NrOfRatings { get; }
        public int NrOfOscars { get; }
    }
}
