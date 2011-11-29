using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Github.API;
using Github.API.Model;
using Github.BlogEngine.Models;

namespace Github.BlogEngine.Repositories
{
    public class PostRepository : IPostRepository
    {
        private const string PostRegx = @"\d\d\d\d/\d\d\d\d\d\d\d\d/.*.htm";

        private Adapter GitAdapter
        {
            get { return new Adapter(); }
        }
        //private static CommitObject _lastCommit = null;
        //private CommitObject LastCommit
        //{
        //    get
        //    {
        //        return _lastCommit ?? GitAdapter.GetAllCommits(GitHubUserSettings.UserName, GitHubUserSettings.Repository,
        //                                                       GitHubUserSettings.Branch)[0];
        //    }
        //}

        public Post GetPost(string path, string treeSha)
        {
            var blob = GitAdapter.GetBlob(GitHubUserSettings.UserName, GitHubUserSettings.Repository, treeSha, path);
            return new Post(blob);
        }

        public IList<Post> GetAllPosts()
        {
            var blobs = GitAdapter.GetBlobs(GitHubUserSettings.UserName, GitHubUserSettings.Repository, GitHubUserSettings.TreeSha);
            var postObjects = blobs.Where(t => Regex.IsMatch(t.Name, PostRegx)).OrderByDescending(p => p.Name);

            var posts = postObjects.Select(postObject => new Post(postObject)).ToList();
            return posts;
        }

        public Post GetPostBySha(string sha)
        {
            var data = GitAdapter.GetBlobsRawData(GitHubUserSettings.UserName, GitHubUserSettings.Repository, sha);
            return new Post{HtmlContent = data};
        }

        public Post GetPostByUrl(string url) {
            return null;
        }
    }
}