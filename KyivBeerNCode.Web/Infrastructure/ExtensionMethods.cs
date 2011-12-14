using System;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace KyivBeerNCode.Web.Infrastructure
{
	public static class ExtensionMethods
	{
		public static MvcHtmlString MenuLink(
			this HtmlHelper htmlHelper,
			string linkText,
			string actionName,
			string controllerName)
		{
			string currentAction = htmlHelper.ViewContext.RouteData.GetRequiredString("action");
			string currentController = htmlHelper.ViewContext.RouteData.GetRequiredString("controller");
			if (controllerName == currentController)
			{
				return htmlHelper.ActionLink(
					linkText,
					actionName,
					controllerName,
					null,
					new
						{
							@class = "active"
						});
			}
			return htmlHelper.ActionLink(linkText, actionName, controllerName);
		}
	}
}