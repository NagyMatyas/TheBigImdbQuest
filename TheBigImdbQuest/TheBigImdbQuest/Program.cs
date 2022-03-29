using System.Collections.ObjectModel;
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
            TestFunction();
        }

        private static void TestFunction()
        {
            Scraper sc = new Scraper();
            sc.ScrappingImdb(25);
            Movie[] movies = sc.Movies;
        }
    }
}
