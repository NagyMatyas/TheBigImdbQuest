using System.Linq;
using System.Threading.Tasks;

namespace TheBigImdbQuest
{
    class TheBigImdbQuest
    {
        private const int NrOfMovies = 20;
        private const int Deviation = 100000;
        private const double Deduction = 0.1;

        private Movie[] movies;

        private readonly IDataSaver saver;
        private readonly Scraper scraper;

        public TheBigImdbQuest(Scraper scraper)
        {
            this.scraper = scraper;
        }

        public TheBigImdbQuest(Scraper scraper, IDataSaver saver)
        {
            this.saver = saver;
            this.scraper = scraper;
        }

        public void ImdbQuest()
        {
            string topListPage = scraper.ScrappingImdb();
            scraper.ExtractTopListHtml(topListPage, NrOfMovies);
            movies = scraper.Movies;

            ReviewPenalizer penalizer = new ReviewPenalizer(Deviation, Deduction);
            int maxNrOfVotes = movies.Max(n => n.NrOfRatings);

            Parallel.ForEach(movies, movie =>
            {
                movie.RecalculatedRating = movie.OriginalRating;
                movie.RecalculatedRating += OscarCalculator.GetOscarRewards(movie.NrOfOscars);
                movie.RecalculatedRating -= penalizer.GetReviewPenalty(maxNrOfVotes, movie.NrOfRatings);
            });

            saver?.SaveFile(movies);
        }
    }
}
