using System;
using System.Linq;
using Github.API;
using Github.API.Model;

namespace Github.BlogEngine.Models
{
    public class Post : GitBaseObject
    {
        private string _title;
        private string _htmlContent;

        public Post()
        {
        }

        public Post(BlobObject blob)
        {
            Path = blob.Name;
            Name = blob.Name;
            HtmlContent = blob.Data;
            Sha = blob.Sha;
            Url = CreatePostUrl(Title);
        }

        public string Title
        {
            get
            {
                if (string.IsNullOrEmpty(_title))
                {
                    try
                    {
                        var htmlTitlt =
                            HtmlContent.Substring(HtmlContent.IndexOf("<title>") + "<title>".Length,
                            HtmlContent.IndexOf("</title>") - HtmlContent.IndexOf("<title>") - "<title>".Length);
                        _title = htmlTitlt;
                    }
                    catch {
                        _title = "No title";                    
                    }

                }
                return _title;
            }
        }

        public string Path { get; set; }

        public string HtmlContent
        {
            get
            {
                if (string.IsNullOrEmpty(_htmlContent))
                {
                    var adapter = new Adapter();
                    _htmlContent = adapter.GetBlobsRawData(GitHubUserSettings.UserName, GitHubUserSettings.Repository, Sha);
                }
                return _htmlContent;
            }
            set { _htmlContent = value; }
        }
        public DateTime CreatedDate { get; set; }

        public string Url { get; set; }

        private string CreatePostUrl(string title) {
            var titleWithoutPunctuation = new string(title.Where(c => !char.IsPunctuation(c)).ToArray());
            return titleWithoutPunctuation.ToLower().Trim().Replace(" ", "-");
        }

    }
}