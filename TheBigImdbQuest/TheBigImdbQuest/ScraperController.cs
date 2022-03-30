using System.Threading.Tasks;
using System.Net.Http;
using System.Collections.Generic;

namespace TheBigImdbQuest
{
    public class ScraperController : IWebPageGetter
    {
        public async Task<string> GetWebPageAsync(string url)
        {
            HttpClient client = new HttpClient();
            var result = client.GetStringAsync(url);
            return await result;
        }

        public async Task<List<string>> GetWebPageAsync(string[] urls)
        {
            List<Task<string>> tasks = new List<Task<string>>();

            foreach (var url in urls)
            {
                async Task<string> func()
                {
                    return await GetWebPageAsync(url);
                }

                tasks.Add(func());
            }

            await Task.WhenAll(tasks);

            List<string> responses = new List<string>();

            foreach (var task in tasks)
            {
                responses.Add(task.Result);
            }

            return await Task.FromResult(responses);
        }
    }
}
