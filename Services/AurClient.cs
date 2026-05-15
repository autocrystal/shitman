using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Shitman
{
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

        public string? GetInstalledVersion(string name)
        {
            if (ProcessRunner.RunWithOutput("pacman", $"-Qi {name}", out string output) != 0)
                return null;

            foreach (var line in output.Split('\n'))
            {
                if (line.StartsWith("Version", StringComparison.OrdinalIgnoreCase))
                {
                    var parts = line.Split(':', 2);
                    if (parts.Length == 2)
                    return parts[1].Trim();
                }
            }
            return null;
        }
    }
}