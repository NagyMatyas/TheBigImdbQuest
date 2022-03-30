using HtmlAgilityPack;

namespace TheBigImdbQuest
{
    interface IHtmlDocument
    {
        HtmlNode DocumentNode { get; }
        void LoadHtml(string html);
    }
}
