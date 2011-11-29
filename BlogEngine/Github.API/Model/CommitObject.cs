using Newtonsoft.Json;

namespace Github.API.Model
{
    public class CommitObject
    {
        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("committed_date")]
        public string CommittedDate { get; set; }

        [JsonProperty("authored_date")]
        public string AuthoredDate { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("tree")]
        public string TreeSha { get; set; }
    }
}