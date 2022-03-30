using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheBigImdbQuest
{
    interface IWebPageGetter
    {
        Task<string> GetWebPageAsync(string url);
        Task<List<string>> GetWebPageAsync(string[] urls);
    }
}
