using System;
using System.Web.Mvc;

namespace KyivBeerNCode.Web.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			return View();
		}
	}
}