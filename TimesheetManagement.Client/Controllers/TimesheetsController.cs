using System.Threading.Tasks;
using System.Web.Mvc;
using TimesheetManagement.Business.Tasks.Entities;
using System;
using System.Linq;
using PagedList;
using TimesheetManagement.Client.Helpers;
using TimesheetManagement.Client.Models;
using TimesheetManagement.Service;

namespace TimesheetManagement.Client.Controllers
{
	public class TimesheetsController : Controller
	{
		private readonly ITimesheetService service;

		public TimesheetsController(ITimesheetService service)
		{
			this.service = service;
		}

		public ActionResult Index()
		{
			TimesheetViewModel model = new TimesheetViewModel();
			model.EmployeeActivities = new StaticPagedList<EmployeeActivity>(Enumerable.Empty<EmployeeActivity>(), 1, 10, 0);
			model.PagingInfo = new PagingInfo(0, 1, 1, 10, "", "");
			return this.View(model);
		}
		
		public async Task<ActionResult> Create()
		{
			throw new NotImplementedException();
		}

		public async Task<ActionResult> Details()
		{
			throw new NotImplementedException();
		}
		
		public async Task<ActionResult> Edit()
		{
			throw new NotImplementedException();
		}

		public async Task<ActionResult> Delete()
		{
			throw new NotImplementedException();
		}
	}
}
