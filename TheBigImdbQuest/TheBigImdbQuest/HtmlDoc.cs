using HtmlAgilityPack;

namespace TheBigImdbQuest
{
    public class HtmlDoc : IHtmlDocument
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
