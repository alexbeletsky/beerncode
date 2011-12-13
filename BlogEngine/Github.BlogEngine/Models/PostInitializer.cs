using System.Collections.Generic;
using System.Linq;
using Github.API;

namespace Github.BlogEngine.Models
{
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
            return paths.Select(path => Initialize((string) path, sha));
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