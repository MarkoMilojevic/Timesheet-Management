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
        private const int pageSize = 5;
        
        public async Task<ActionResult> Index(int page = 1)
        {
            List<TaskActivity> taskActivities = (await TaskActivitiesApiService.GetByEmployeeAsync(1)).ToList();

            TaskActivitiesViewModel model = new TaskActivitiesViewModel();
            model.TaskActivityViewModels =  new StaticPagedList<TaskActivity>(taskActivities.Skip((page - 1) * pageSize).Take(pageSize), page, pageSize, taskActivities.Count);
            model.PagingInfo = new PagingInfo(taskActivities.Count, (int)Math.Ceiling((double)taskActivities.Count / pageSize), page, pageSize, "", "");

            return View("Index", model);
        }

        [HttpGet]
        public async Task<ActionResult> AddTaskActivity()
        {
            List<Entities.Client> clients = (await ClientsApiService.GetAsync()).ToList();

            ViewBag.Accounts = new SelectList(clients.Select(account => new { Value = account.TaxpayerIdentificationNumber, Text = account.Name }), "Value", "Text");

            return View("_TaskActivity");
        }

        public async Task<ActionResult> GetTaskActivitiesViewModel(int page = 1)
        {
            if (!Request.IsAjaxRequest())
            {
                
            }

            List<TaskActivity> taskActivities = (await TaskActivitiesApiService.GetByEmployeeAsync(1)).ToList();

            TaskActivitiesViewModel model = new TaskActivitiesViewModel();
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

            await TaskActivitiesApiService.PostAsync(taskActivity);

            return RedirectToAction("Index", "Timesheets");
        }

        public async Task<ActionResult> GetAccounts()
        {
            List<Entities.Client> clients = (await ClientsApiService.GetAsync()).ToList();

            return Json(
                clients.Select(c => new { Value = c.TaxpayerIdentificationNumber, Text = c.Name }), 
                JsonRequestBehavior.AllowGet
            );
        }
        
        public async Task<ActionResult> GetProjects(string clientId)
        {
            List<Project> projects = (await ProjectsApiService.GetByClientAsync(clientId)).ToList();

            return Json(
                projects.Select(project => new { Value = project.ProjectId, Text = project.Name }),
                JsonRequestBehavior.AllowGet
            );
        }
        
        public async Task<ActionResult> GetTasks(int projectId)
        {
            List<Task> tasks = (await TasksApiService.GetByProjectAsync(projectId)).ToList();

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
