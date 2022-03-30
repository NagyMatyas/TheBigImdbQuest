using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;
using HtmlAgilityPack;
using TheBigImdbQuest;
using System.IO;

namespace TheBigImdbQuest_Test
{
    public class Scraper_Test
    {
        Scraper scraper;

        [SetUp]
        public void SetUp()
        {
            scraper = new Scraper(new ScraperController(), new HtmlDoc(), ImdbXPath.XPaths);
        }

        [Test]
        public void Html_DataExtract()
        {
            int test_nrOfMovies = 5;
            string top5page = File.ReadAllText("Top5Movies.html");

            scraper.ExtractTopListHtml(top5page, test_nrOfMovies);


            Assert.AreEqual(5, scraper.Movies.Length);
            Assert.AreEqual("A remény rabjai", scraper.Movies[0].Title);
            Assert.AreEqual("A keresztapa", scraper.Movies[1].Title);
            Assert.AreEqual("A sötét lovag", scraper.Movies[2].Title);
            Assert.AreEqual("A keresztapa II", scraper.Movies[3].Title);
            Assert.AreEqual("Tizenkét dühös ember", scraper.Movies[4].Title);

            Assert.AreEqual(0, scraper.Movies[0].NrOfOscars);
            Assert.AreEqual(3, scraper.Movies[1].NrOfOscars);
            Assert.AreEqual(2, scraper.Movies[2].NrOfOscars);
            Assert.AreEqual(6, scraper.Movies[3].NrOfOscars);
            Assert.AreEqual(0, scraper.Movies[4].NrOfOscars);

            Assert.AreEqual(9.2, scraper.Movies[0].OriginalRating);
            Assert.AreEqual(9.2, scraper.Movies[1].OriginalRating);
            Assert.AreEqual(9.0, scraper.Movies[2].OriginalRating);
            Assert.AreEqual(9.0, scraper.Movies[3].OriginalRating);
            Assert.AreEqual(9.0, scraper.Movies[4].OriginalRating);

        }
    }
}
