using System;
using System.Web.Mvc;
using Github.BlogEngine.Models;
using Github.BlogEngine.Repositories;
using PagedList;

namespace KyivBeerNCode.Web.Controllers
{
	public class BlogController : Controller
	{
		private readonly IPostRepository _posts;

		public BlogController(IPostRepository posts)
		{
			_posts = posts;
		}

		public ActionResult Posts(int? page)
		{
			var paged = new PagedList<Post>(_posts.GetAllPosts(), page ?? 1, 10);
			return View("Posts", paged);
		}

		public ActionResult Post(string sha)
		{
			var post = _posts.GetPostBySha(sha);
			return View(post);
		}
	}
}