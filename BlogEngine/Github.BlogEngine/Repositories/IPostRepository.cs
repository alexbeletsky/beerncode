using System;
using System.Collections.Generic;
using Github.BlogEngine.Models;

namespace Github.BlogEngine.Repositories {
    public interface IPostRepository {
        IList<Post> GetAllPosts();
        Post GetPost(string path, string treeSha);
        Post GetPostBySha(string sha);
        Post GetPostByUrl(string url);
    }
}
