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

        public BlogController(IPostRepository posts) {
            _posts = posts;
        }

        public ActionResult Posts(int? page)
        {
            PagedList<Post> paged = new PagedList<Post>(_posts.GetAllPosts(), page ?? 1, 10);
            return View("Posts",paged);
        }

        public ActionResult Post(string sha)
        {
            var post = _posts.GetPostBySha(sha);
            return View(post);
        }
    }
}
