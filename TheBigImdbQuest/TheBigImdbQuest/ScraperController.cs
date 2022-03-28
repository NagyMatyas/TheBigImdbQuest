using System.Threading.Tasks;
using System.Net.Http;
using System.Collections.Generic;

namespace TheBigImdbQuest
{
    class ScraperController
    {
        readonly string baseUrl = @"https://www.imdb.com";

        public async Task<string> GetUrlAsync(string url)
        {
            HttpClient client = new HttpClient();
            var result = client.GetStringAsync(url);
            return await result;
        }

        public async Task<List<string>> GetUrlAsync(string[] urlPostfix)
        {
            List<Task<string>> tasks = new List<Task<string>>();

            foreach (var post in urlPostfix)
            {
                async Task<string> func()
                {
                    return await GetUrlAsync(baseUrl + post);
                }

                tasks.Add(func());
            }

            await Task.WhenAll(tasks);

            List<string> responses = new List<string>();

            foreach (var task in tasks)
            {
                responses.Add(await task);
            }

            return await Task.FromResult(responses);
        }
    }
}
