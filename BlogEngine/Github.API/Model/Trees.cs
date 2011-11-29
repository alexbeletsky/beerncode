using Newtonsoft.Json;

namespace Github.API.Model
{
    public class Trees
    {
        [JsonProperty("tree")]
        public TreeObject[] TreeObjects { get; set; }
    }
}