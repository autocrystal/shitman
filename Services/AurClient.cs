using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Shitman
{
    public class AurResponse
    {
        [JsonPropertyName("results")]
        public List<AurPackage> Results { get; set; }
    }

    [JsonSerializable(typeof(AurResponse))]
    internal partial class AurJsonContext : JsonSerializerContext {}

    public class AurClient
    {
        static HttpClient client;

        public void Init()
        {
            client = new HttpClient();
        }

        public async Task<List<AurPackage>?> Search(string query)
        {
            string url = $"https://aur.archlinux.org/rpc/?v=5&type=search&by=name&arg={query}";
            string json = await client.GetStringAsync(url);
            AurResponse? response = JsonSerializer.Deserialize(json, AurJsonContext.Default.AurResponse);
            return response?.Results;
        }

        public async Task<AurPackage?> GetPackage(string name)
        {
            string url = $"https://aur.archlinux.org/rpc/?v=5&type=info&arg[]={name}";
            string json = await client.GetStringAsync(url);
            AurResponse? response = JsonSerializer.Deserialize(json, AurJsonContext.Default.AurResponse);
            if (response?.Results == null || response.Results.Count == 0)
            {
                return null;
            }
            return response?.Results?.FirstOrDefault();
        }
    }
}