using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using TimesheetManagement.Client.Mvc.Models;
using TimesheetManagement.Client.Mvc.Services;

namespace TimesheetManagement.Client.Mvc.Controllers
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
		public async Task<ActionResult> Edit()
		{
			throw new NotImplementedException();
		}

		public async Task<ActionResult> Delete()
		{
			throw new NotImplementedException();
		}

		public async Task<ActionResult> Details()
		{
			throw new NotImplementedException();
		}
	}
}
