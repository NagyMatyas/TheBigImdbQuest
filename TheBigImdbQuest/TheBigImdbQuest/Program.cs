using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace TheBigImdbQuest
{
    class Program
    {
        static void Main(string[] args)
        {
            TestFunction();//.Wait();
        }

        private static void TestFunction()
        {
            Movie[] movies = new Movie[20];
            ScraperController sc = new ScraperController();
            string url = @"https://www.imdb.com/chart/top/";

            string topListPage = sc.GetUrlAsync(url).Result;

            HtmlDocument htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(topListPage);

            var titleTopMovies = htmlDoc.DocumentNode.SelectNodes("//tbody//tr//td[@class='titleColumn']//a")
                .Select(n => n.InnerText)
                .Take(movies.Length).ToArray();

            var linkTopMovies = htmlDoc.DocumentNode.SelectNodes("//tbody//tr//td[@class='titleColumn']//a")
                .Select(n => n.Attributes["href"].Value)
                .Take(movies.Length).ToArray();

            var rate = htmlDoc.DocumentNode.SelectNodes("//tbody//tr//td[@class='posterColumn']//span[@name='ir']")
                .Select(n => n.Attributes["data-value"].Value)
                .Take(movies.Length).ToArray();

            var nrOfVotes = htmlDoc.DocumentNode.SelectNodes("//tbody//tr//td[@class='posterColumn']//span[@name='nv']")
                .Select(n => n.Attributes["data-value"].Value)
                .Take(movies.Length).ToArray();

            string[] oscarList = sc.GetUrlAsync(linkTopMovies).Result.ToArray();

            Parallel.For(0, movies.Length, i =>
            {
                movies[i] = new Movie(titleTopMovies[i],
                                      double.Parse(rate[i], CultureInfo.InvariantCulture),
                                      0,
                                      int.Parse(nrOfVotes[i]),
                                      GetOscars(oscarList[i]));
            });
        }

        private static int GetOscars(string html)
        {
            int result = 0;
            HtmlDocument htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(html);

            var titlesTop = htmlDoc.DocumentNode
                .SelectNodes("//li[@data-testid='award_information']//a")
                .Select(n => n.InnerText);

            if (titlesTop.FirstOrDefault().Contains("Won"))
            {
                Regex reg = new Regex(@"(\d+)");
                var a = reg.Match(titlesTop.FirstOrDefault()).Groups[0].Value;
                result = int.Parse(a);
            }

            return result;
        }
    }
}
