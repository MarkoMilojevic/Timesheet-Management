﻿using System.Web.Mvc;

namespace TimesheetManagement.Service.Controllers
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
