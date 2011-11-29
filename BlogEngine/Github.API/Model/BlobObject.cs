using Newtonsoft.Json;

namespace Github.API.Model
{
    //[JsonObject("blob")]
    public class BlobObject
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("data")]
        public string Data { get; set; }
        [JsonProperty("size")]
        public int Size { get; set; }
        [JsonProperty("sha")]
        public string Sha { get; set; }
        [JsonProperty("mode")]
        public string Mode { get; set; }
        [JsonProperty("mime_type")]
        public string MimeType { get; set; }
    }
}