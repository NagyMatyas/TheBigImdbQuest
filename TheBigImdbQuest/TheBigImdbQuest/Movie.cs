namespace TheBigImdbQuest
{
    public class Movie
    {
        public string Title { get; set; }
        public double OriginalRating { get; set; }
        public double RecalculatedRating { get; set; }
        public int NrOfRatings { get; set; }
        public int NrOfOscars { get; set; }

        public override string ToString()
        {
            return $"Title: '{Title}', " +
                   $"OriginalRating: '{OriginalRating}', " +
                   $"RecalculatedRating: '{RecalculatedRating}', " +
                   $"NrOfRatings: '{NrOfRatings}', " +
                   $"NrOfOscars: '{NrOfOscars}'";
        }
    }
}
