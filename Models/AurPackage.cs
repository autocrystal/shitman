using System.Text.Json.Serialization;

namespace Shitman
{
    public class AurPackage
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int PackageBaseID { get; set; }
        public string PackageBase { get; set; }
        public string Version { get; set; }
        public string Description { get; set; }
        public string URL { get; set; }
        public int NumVotes { get; set; }
        public double Popularity { get; set; }
        public long? OutOfDate { get; set; } 
        public string Maintainer { get; set; }
        public long FirstSubmitted { get; set; }
        public long LastModified { get; set; }
        public string URLPath { get; set; }

        [JsonPropertyName("Depends")]
        public List<string>? Depends { get; set; }

        [JsonPropertyName("MakeDepends")]
        public List<string>? MakeDepends { get; set; }

        [JsonPropertyName("OptDepends")]
        public List<string>? OptDepends { get; set; }

        [JsonPropertyName("CheckDepends")]
        public List<string>? CheckDepends { get; set; }

        [JsonPropertyName("Conflicts")]
        public List<string>? Conflicts { get; set; }

        [JsonPropertyName("Provides")]
        public List<string>? Provides { get; set; }

        [JsonPropertyName("Replaces")]
        public List<string>? Replaces { get; set; }

        [JsonPropertyName("Groups")]
        public List<string>? Groups { get; set; }

        [JsonPropertyName("License")]
        public List<string>? License { get; set; }

        [JsonPropertyName("Keywords")]
        public List<string>? Keywords { get; set; }
    }
}