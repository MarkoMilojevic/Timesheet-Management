using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using PagedList;
using TimesheetManagement.Client.Common.Helpers;
using TimesheetManagement.Client.Models;
using TimesheetManagement.Client.Services;

namespace TimesheetManagement.Client.Controllers
{
	public class TimesheetsController : Controller
	{
		private readonly ApiTimesheetService service;

        public TimesheetsController()
        {
            this.service = new ApiTimesheetService();
        }

		public async Task<ActionResult> Index()
		{
            TimesheetViewModel model = new TimesheetViewModel();
            model.Accounts = await service.GetAccountsAsync();
            //model.PagingInfo = new PagingInfo(0, 1, 1, 10, "", "");
            return View(model);
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
