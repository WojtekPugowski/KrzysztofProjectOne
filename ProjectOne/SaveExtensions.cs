using System.Text;
using System.Text.Json;

namespace ProjectOne
{
    public static class SaveExtensions
    {

        public static void SaveToFile(this Repository repo, string fileName)
        {
            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            };
            string serializatedRepo = JsonSerializer.Serialize(repo, options);

            using (var fileStream = new FileStream(fileName, FileMode.Create))
            {
                byte[] bytes = Encoding.UTF8.GetBytes(serializatedRepo);
                fileStream.Write(bytes);
            }
        }     }
}