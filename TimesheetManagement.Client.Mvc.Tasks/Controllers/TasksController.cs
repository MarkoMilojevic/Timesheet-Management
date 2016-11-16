using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using PagedList;
using TimesheetManagement.Client.Mvc.Common.Entities;
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
        private const int pageSize = 5;

        public TasksController()
        {
            this.service = new TasksApiService();
        }

        public async Task<ActionResult> Index(int page = 1)
        {
            TaskActivitiesViewModel model = new TaskActivitiesViewModel();
            ICollection<TaskActivity> taskActivities = await service.GetTaskActivitiesAsync(1);
            model.TaskActivityViewModels =  new StaticPagedList<TaskActivity>(taskActivities.Skip((page - 1) * pageSize).Take(pageSize), page, pageSize, taskActivities.Count);
            model.PagingInfo = new PagingInfo(taskActivities.Count, (int)Math.Ceiling((double)taskActivities.Count / pageSize), page, pageSize, "", "");
            return View("Index", model);
        }

        [HttpGet]
        public async Task<ActionResult> AddTaskActivity()
        {
            ICollection<Entities.Client> accounts = await service.GetAccountsAsync();
            ViewBag.Accounts = new SelectList(accounts.Select(account => new { Value = account.TaxpayerIdentificationNumber, Text = account.Name }), "Value", "Text");

            return View("_TaskActivity");
        }

        public async Task<ActionResult> GetTaskActivitiesViewModel(int page = 1)
        {
            if (!Request.IsAjaxRequest())
            {
                
            }

            TaskActivitiesViewModel model = new TaskActivitiesViewModel();
            ICollection<TaskActivity> taskActivities = await service.GetTaskActivitiesAsync(1);
            model.TaskActivityViewModels = new StaticPagedList<TaskActivity>(taskActivities.Skip((page - 1) * pageSize).Take(pageSize), page, pageSize, taskActivities.Count);
            model.PagingInfo = new PagingInfo(taskActivities.Count, (int)Math.Ceiling((double)taskActivities.Count / pageSize), page, pageSize, "", "");

            return PartialView("_TaskActivitiesTable", model);
        }

        [HttpPost]
        public async Task<ActionResult> AddTaskActivity(TaskActivity model)
        {
            if (ModelState.IsValid)
            {
                
            }

            model.Activity.Employee = new Employee
            {
                EmployeeId = 1
            };

            TaskActivity taskActivity = new TaskActivity
            {
                Task = model.Task,
                Activity = model.Activity
            };

            await service.CreateTaskActivityAsync(taskActivity);
            return RedirectToAction("Index", "Timesheets");
        }

        public async Task<ActionResult> GetAccounts()
        {
            ICollection<Entities.Client> accounts = await service.GetAccountsAsync();

            return Json(
                accounts.Select(account => new { Value = account.TaxpayerIdentificationNumber, Text = account.Name }), 
                JsonRequestBehavior.AllowGet
            );
        }
        
        public async Task<ActionResult> GetProjects(string accountId)
        {
            ICollection<Project> projects = await service.GetProjectsAsync(accountId);

            return Json(
                projects.Select(project => new { Value = project.ProjectId, Text = project.Name }),
                JsonRequestBehavior.AllowGet
            );
        }
        
        public async Task<ActionResult> GetTasks(int projectId)
        {
            ICollection<Task> tasks = await service.GetTasksAsync(projectId);

            return Json(
                tasks.Select(task => new { Value = task.TaskId, Text = task.Name }),
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
