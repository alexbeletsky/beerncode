using Newtonsoft.Json;

namespace Github.API.Model
{
    public class Blob
    {
        [JsonProperty("blob")]
        public BlobObject BlobObject { get; set; }
    }
}