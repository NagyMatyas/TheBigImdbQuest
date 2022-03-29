using Newtonsoft.Json;
using System.IO;

namespace TheBigImdbQuest
{
    class ToJSON : IDataSaver
    {
        public void SaveFile(Movie[] movies)
        {
            using (StreamWriter file = File.CreateText(@"movie.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, movies);
            }
        }
    }
}
