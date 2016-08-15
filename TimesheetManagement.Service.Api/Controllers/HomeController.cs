using System.Web.Mvc;

namespace TimesheetManagement.Service.Api.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			this.ViewBag.Title = "Home Page";

			return this.View();
		}
	}
}
