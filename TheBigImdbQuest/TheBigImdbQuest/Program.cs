namespace TheBigImdbQuest
{
    class Program
    {
        static void Main(string[] args)
        {
            var quest = new TheBigImdbQuest(new Scraper(), new ToJSON());

            quest.ImdbQuest();
        }
    }
}
