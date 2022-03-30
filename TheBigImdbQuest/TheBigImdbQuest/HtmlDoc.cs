using HtmlAgilityPack;

namespace TheBigImdbQuest
{
    class HtmlDoc : IHtmlDocument
    {
        HtmlDocument htmlDoc;

        public HtmlDoc()
        {
            htmlDoc = new HtmlDocument();
        }

        public HtmlNode DocumentNode { get => htmlDoc.DocumentNode; }

        public void LoadHtml(string html)
        {
            htmlDoc.LoadHtml(html);
        }
    }
}
