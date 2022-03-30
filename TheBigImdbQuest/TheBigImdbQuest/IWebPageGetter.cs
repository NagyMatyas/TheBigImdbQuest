using System.Collections.Generic;
using System.Threading.Tasks;

namespace TheBigImdbQuest
{
    public interface IWebPageGetter
    {
        Task<string> GetWebPageAsync(string url);
        Task<List<string>> GetWebPageAsync(string[] urls);
    }
}
