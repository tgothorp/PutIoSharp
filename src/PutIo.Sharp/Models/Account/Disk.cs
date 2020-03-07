using System.Text.Json.Serialization;

namespace PutIo.Sharp.Models.Account
{
    public class Disk
    {
        [JsonPropertyName("avail")]
        public long Available { get; set; }
        
        [JsonPropertyName("size")]
        public long Size { get; set; }
        
        [JsonPropertyName("used")]
        public long Used { get; set; }
    }
}