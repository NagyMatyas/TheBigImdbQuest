namespace TheBigImdbQuest
{
    class Program
    {
        static void Main(string[] args)
        {
            var quest = new TheBigImdbQuest(new Scraper(new ScraperController(), new HtmlDoc(), ImdbXPath.XPaths), new ToJSON());

            quest.ImdbQuest();
        }
    }
}
