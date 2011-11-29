using Newtonsoft.Json;

namespace Github.API.Model
{
    public class Blobs
    {
        [JsonProperty("blobs")]
        public BlobObject[] BlobObject { get; set; }
    }
}