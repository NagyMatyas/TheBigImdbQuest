using System.Threading.Tasks;
using System.Net.Http;
using System.Collections.Generic;

namespace TheBigImdbQuest
{
    static class ScraperController
    {
        public static async Task<string> GetUrlAsync(string url)
        {
            HttpClient client = new HttpClient();
            var result = client.GetStringAsync(url);
            return await result;
        }

        public static async Task<List<string>> GetUrlAsync(string[] urls)
        {
            List<Task<string>> tasks = new List<Task<string>>();

            foreach (var url in urls)
            {
                async Task<string> func()
                {
                    return await GetUrlAsync(url);
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
