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

        //we should use the last commit treesha.
        //the default sha is not a correct way. It some time returns blob metadata that does not exist now.
        //it works kinda tricky
        private static CommitObject _lastCommit = null;
        private CommitObject LastCommit
        {
            get
            {
                return _lastCommit ?? GitAdapter.GetAllCommits(GitHubUserSettings.UserName, GitHubUserSettings.Repository,
                                                               GitHubUserSettings.Branch).First();
            }
        }

        public Post GetPost(string path, string treeSha)
        {
            var blob = GitAdapter.GetBlob(GitHubUserSettings.UserName, GitHubUserSettings.Repository, treeSha, path);
            return new Post(blob);
        }

        public IList<Post> GetAllPosts()
        {
            var blobs = GitAdapter.GetBlobs(GitHubUserSettings.UserName, GitHubUserSettings.Repository, LastCommit.TreeSha);
            var postObjects = blobs.Where(t => Regex.IsMatch(t.Name, PostRegx)).OrderByDescending(p => p.Name);

            var posts = postObjects.Select(postObject => new Post(postObject)).ToList();
            return posts;
        }


        public IEnumerable<Post>  GetPagedPosts(int page, int pageSize)
        {
            var all = GitAdapter.GetBlobAll(GitHubUserSettings.UserName, GitHubUserSettings.Repository,
                                            GitHubUserSettings.Branch, LastCommit.TreeSha);
            var posts = all.GetHtmlFiles();

            return PostInitializer.InitializePagePosts(posts.Select(b => b.Key), LastCommit.TreeSha, page, pageSize);

        }

        public Post GetPostBySha(string sha)
        {
            var data = GitAdapter.GetBlobsRawData(GitHubUserSettings.UserName, GitHubUserSettings.Repository, sha);
            return new Post{ HtmlContent = data, Body = data.GetBody(), Sha = sha };
        }

        public Post GetPostByUrl(string url) {
            return null;
        }
    }
}