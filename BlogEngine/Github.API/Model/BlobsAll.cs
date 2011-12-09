using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using System;

namespace Github.API.Model
{
    public class BlobsAll
    {
        [JsonProperty("blobs")]
        public IDictionary<string, string> Blobs { get; set; }
    }

    public static class BlobsAllExtension
    {
        private const string HtmlFileRegx = @"\d\d\d\d/\d\d\d\d\d\d\d\d/.*.htm";

        public static IDictionary<string, string> GetHtmlFiles(this BlobsAll @this)
        {
            var files = @this.Blobs.Where(f => Regex.IsMatch(f.Key, HtmlFileRegx))
            .OrderByDescending(f => f.Key).ToDictionary(d => d.Key, d => d.Value);

            return files;
        }
    }
}