using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using TimesheetManagement.Client.Mvc.Common.Services;
using TimesheetManagement.Client.Mvc.Tasks.Entities;

namespace TimesheetManagement.Client.Mvc.Tasks.Services
{
	public static class TaskActivitiesApiService
	{
        public static async Task<TaskActivity> GetAsync(int taskId, int activityId)
        {
            return await ApiService.Get<TaskActivity>($"api/taskactivities/{taskId}/{activityId}");
        }

        public static async Task<IEnumerable<TaskActivity>> GetAsync()
        {
            return await ApiService.Get<IEnumerable<TaskActivity>>("api/taskactivities");
        }

        public static async Task<IEnumerable<TaskActivity>> GetByTaskAsync(int taskId)
        {
            return await ApiService.Get<IEnumerable<TaskActivity>>($"api/tasks/{taskId}/taskactivities");
        }

        public static async Task<IEnumerable<TaskActivity>> GetByActivityAsync(int activityId)
        {
            return await ApiService.Get<IEnumerable<TaskActivity>>($"api/activities/{activityId}/taskactivities");
        }

        public static async Task<IEnumerable<TaskActivity>> GetByEmployeeAsync(int employeeId)
        {
            return await ApiService.Get<IEnumerable<TaskActivity>>($"api/employees/{employeeId}/taskactivities");
        }

        public static async Task<HttpResponseMessage> PostAsync(TaskActivity taskActivity)
        {
            return await ApiService.PostAsync("api/taskactivities/", taskActivity);
        }
    }
}
