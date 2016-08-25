using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using PagedList;
using TimesheetManagement.Client.Mvc.Common.Helpers;
using TimesheetManagement.Client.Mvc.Tasks.Entities;
using TimesheetManagement.Client.Mvc.Tasks.Models;
using TimesheetManagement.Client.Mvc.Tasks.Services;
using Task = TimesheetManagement.Client.Mvc.Tasks.Entities.Task;

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
            TaskActivitiesViewModel model = new TaskActivitiesViewModel();
            IEnumerable<TaskActivityViewModel> taskActivities = await service.GetTaskActivitiesAsync(1);
            model.TaskActivityViewModels =  new StaticPagedList<TaskActivityViewModel>(taskActivities, 1, 10, 0);
            model.PagingInfo = new PagingInfo(0, 1, 1, 10, "", "");
            return View("Index", model);
        }

        public async Task<ActionResult> GetTaskActivity()
        {
            ICollection<Account> accounts = await service.GetAccountsAsync();
            ViewBag.Accounts = new SelectList(accounts.Select(a => new { Value = a.TaxpayerIdentificationNumber, Text = a.Name }), "Value", "Text");

            return View("_TaskActivity", new TaskActivityViewModel());
        }

        public async Task<ActionResult> GetAccounts()
        {
            ICollection<Account> accounts = await service.GetAccountsAsync();

            return Json(
                accounts.Select(a => new { Id = a.TaxpayerIdentificationNumber, Value = a.Name }), 
                JsonRequestBehavior.AllowGet
            );
        }
        
        public async Task<ActionResult> GetProjects(string accountId)
        {
            ICollection<Project> projects = await service.GetProjectsAsync(accountId);

            return Json(
                projects.Select(p => new { Id = p.ProjectId, Value = p.Name }),
                JsonRequestBehavior.AllowGet
            );
        }
        
        public async Task<ActionResult> GetTasks(int projectId)
        {
            ICollection<Task> projects = await service.GetTasksAsync(projectId);

            return Json(
                projects.Select(t => new { Id = t.TaskId, Value = t.Name }),
                JsonRequestBehavior.AllowGet
            );
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
