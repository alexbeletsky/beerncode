using Newtonsoft.Json;

namespace Github.API.Model
{
    public class Commits
    {
        [JsonProperty("commits")]
        public CommitObject[] CommitObjects { get; set; }
    }
}