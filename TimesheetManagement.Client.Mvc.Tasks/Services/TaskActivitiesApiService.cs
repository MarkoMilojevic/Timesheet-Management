using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using TimesheetManagement.Client.Mvc.Common.Services;
using TimesheetManagement.Client.Mvc.Tasks.Entities;

namespace TimesheetManagement.Client.Mvc.Tasks.Services
{
	public static class TaskActivitiesApiService
	{
        private const string ControllerActionUri = "api/taskactivities/";

        public static async Task<TaskActivity> GetAsync(int taskId, int activityId)
        {
            return await ApiService.GetAsync<TaskActivity>(ControllerActionUri + $"{taskId}/{activityId}");
        }

        public static async Task<IEnumerable<TaskActivity>> GetAsync()
        {
            return await ApiService.GetAsync<IEnumerable<TaskActivity>>(ControllerActionUri);
        }

        public static async Task<IEnumerable<TaskActivity>> GetByTaskAsync(int taskId)
        {
            return await ApiService.GetAsync<IEnumerable<TaskActivity>>($"api/tasks/{taskId}/taskactivities");
        }

        public static async Task<IEnumerable<TaskActivity>> GetByActivityAsync(int activityId)
        {
            return await ApiService.GetAsync<IEnumerable<TaskActivity>>($"api/activities/{activityId}/taskactivities");
        }

        public static async Task<IEnumerable<TaskActivity>> GetByEmployeeAsync(int employeeId)
        {
            return await ApiService.GetAsync<IEnumerable<TaskActivity>>($"api/employees/{employeeId}/taskactivities");
        }

        public static async Task<HttpResponseMessage> PutAsync(TaskActivity task)
        {
            return await ApiService.PutAsync(ControllerActionUri, task);
        }

        public static async Task<HttpResponseMessage> PostAsync(TaskActivity task)
        {
            return await ApiService.PostAsync(ControllerActionUri, task);
        }

        public static async Task<HttpResponseMessage> DeleteAsync(int taskId)
        {
            return await ApiService.DeleteAsync(ControllerActionUri + taskId);
        }
    }
}
