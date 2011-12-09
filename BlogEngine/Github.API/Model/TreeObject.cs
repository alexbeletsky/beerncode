using Newtonsoft.Json;

namespace Github.API.Model
{
    public class TreeObject
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("sha")]
        public string Sha { get; set; }

        [JsonProperty("mode")]
        public string Mode { get; set; }

        [JsonProperty("mime_type")]
        public string MimeType { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }
}