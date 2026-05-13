using System.Text.Json.Serialization;

namespace Shitman
{
    public class AurPackage
    {
        public string Name { get; set; }
        public string Version { get; set; }
        public string Description { get; set; }
        
        [JsonPropertyName("Depends")]
        public List<string>? Depends { get; set; }

        [JsonPropertyName("MakeDepends")]
        public List<string>? MakeDepends { get; set; }

        [JsonPropertyName("CheckDepends")]
        public List<string>? CheckDepends { get; set; }
        
        public string URLPath { get; set; }
        public int ID { get; set; }
    }
}