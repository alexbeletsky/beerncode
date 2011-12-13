using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Caching;
using System.Web.Mvc;
using Github.BlogEngine;
using Github.BlogEngine.Models;
using Github.BlogEngine.Repositories;
using PagedList;

namespace KyivBeerNCode.Web.Controllers
{
    public class BlogController : Controller
    {
        IPostRepository _posts;

        public BlogController(IPostRepository posts)
        {
            _posts = posts;
        }

        //if the user will be browsing the post fast there will be a 403 error from github.
        //there will be problems if multiple users will be browsing the blog at the same time (can be solved by caching the results)
        //figure out how to fix this for the feature.
        public ActionResult Posts(int? page)
        {
            PagedList<Post> paged = new PagedList<Post>(_posts.GetPagedPosts(page ?? 1, 10), page ?? 1, 10);
            return View("Posts", paged);
        }

        public ActionResult Post(string sha)
        {
            var post = _posts.GetPostBySha(sha);
            return View(post);
        }
    }
}
