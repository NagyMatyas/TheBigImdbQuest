using HtmlAgilityPack;

namespace TheBigImdbQuest
{
    public interface IHtmlDocument
    {
        HtmlNode DocumentNode { get; }
        void LoadHtml(string html);
    }
}
