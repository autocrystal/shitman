using System.Text.Json.Serialization;
namespace Shitman
{
    public class AurPackage
    {
        [JsonPropertyName("ID")]
        public int ID { get; set; }

        [JsonPropertyName("Name")]
        public string Name { get; set; }

        [JsonPropertyName("PackageBaseID")]
        public int PackageBaseID { get; set; }

        [JsonPropertyName("PackageBase")]
        public string PackageBase { get; set; }

        [JsonPropertyName("Version")]
        public string Version { get; set; }

        [JsonPropertyName("Description")]
        public string Description { get; set; }

        [JsonPropertyName("URL")]
        public string URL { get; set; }

        [JsonPropertyName("NumVotes")]
        public int NumVotes { get; set; }

        [JsonPropertyName("Popularity")]
        public double Popularity { get; set; }

        [JsonPropertyName("OutOfDate")]
        public long? OutOfDate { get; set; }

        [JsonPropertyName("Maintainer")]
        public string Maintainer { get; set; }

        [JsonPropertyName("FirstSubmitted")]
        public long FirstSubmitted { get; set; }

        [JsonPropertyName("LastModified")]
        public long LastModified { get; set; }

        [JsonPropertyName("URLPath")]
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

    public class AurResponse
    {
        [JsonPropertyName("version")]
        public int Version { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("resultcount")]
        public int ResultCount { get; set; }

        [JsonPropertyName("results")]
        public List<AurPackage> Results { get; set; }
    }

    [JsonSerializable(typeof(AurResponse))]
    public partial class AurJsonContext : JsonSerializerContext { }
}