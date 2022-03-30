namespace TheBigImdbQuest
{
    class Program
    {
        static void Main(string[] args)
        {
            var quest = new TheBigImdbQuest(new Scraper(new ScraperController(), new HtmlDoc()), new ToJSON());

            quest.ImdbQuest();
        }
    }
}
