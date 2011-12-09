using System;
using System.Collections.Generic;
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
                    // todo: create a class with parsing and initialization logic
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

    public  class PostInitializer 
    {
        
        public static Post Initialize(string path, string sha)
        {
            var adapter = new Adapter();
            var blob = adapter.GetBlob(GitHubUserSettings.UserName, GitHubUserSettings.Repository, sha, path);
            var post = new Post(blob);
            return post;
        }

        internal static IEnumerable<Post> Initialize(IEnumerable<string> paths, string sha)
        {
            return paths.Select(path => Initialize(path, sha));
        }

        internal static IEnumerable<Post> InitializePagePosts(IEnumerable<string> paths, string sha, int page, int pageSize)
        {
            List<Post> posts = new List<Post>();
            //todo: should be refactored (find a more clear and right way)
            //a hack, so that to pass a partially initialized list to PagedList in the controller
            var itemsBefore = paths.Take((page - 1)*pageSize);
            var itemsToInitialize =  paths.Skip((page - 1)*pageSize).Take(pageSize);
            var itemsAfter = paths.Skip((page - 1)*pageSize + pageSize);
            posts.AddRange(itemsBefore.Select(path => new Post( ){Path = path}));
            posts.AddRange(Initialize(itemsToInitialize, sha));
            posts.AddRange(itemsAfter.Select(path=> new Post( ){Path = path}));
            return posts;
        }
    }
}