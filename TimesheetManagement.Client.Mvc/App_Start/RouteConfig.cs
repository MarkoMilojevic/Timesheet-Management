using System.Web.Mvc;
using System.Web.Routing;

namespace TimesheetManagement.Client.Mvc
{
	public class RouteConfig
	{
		public static void RegisterRoutes(RouteCollection routes)
		{
			routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

			routes.MapRoute(
				"Default",
				"{controller}/{action}/{id}",
				new {controller = "Timesheets", action = "Index", id = UrlParameter.Optional}
			);
		}
	}
}
