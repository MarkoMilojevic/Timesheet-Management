using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using PagedList;
using TimesheetManagement.Client.Mvc.Common.Helpers;
using TimesheetManagement.Client.Mvc.Tasks.Entities;
using TimesheetManagement.Client.Mvc.Tasks.Models;
using TimesheetManagement.Client.Mvc.Tasks.Services;

namespace TimesheetManagement.Client.Mvc.Tasks.Controllers
{
    public class TasksController : Controller
    {
        private readonly TasksApiService service;

        public TasksController()
        {
            this.service = new TasksApiService();
        }

        public async Task<ActionResult> Index()
        {
            TaskActivityViewModel model = new TaskActivityViewModel();
            IEnumerable<Account> accounts = await service.GetAccountsAsync();
            model.Accounts =  new StaticPagedList<Account>(accounts, 1, 10, 0);
            model.PagingInfo = new PagingInfo(0, 1, 1, 10, "", "");
            return View("Index", model);
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
