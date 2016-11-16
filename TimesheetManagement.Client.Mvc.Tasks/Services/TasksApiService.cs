using System.Collections.Generic;
using System.Threading.Tasks;
using TimesheetManagement.Client.Mvc.Common.Services;
using Task = TimesheetManagement.Client.Mvc.Tasks.Entities.Task;

namespace TimesheetManagement.Client.Mvc.Tasks.Services
{
	public static class TasksApiService
	{
        public static async Task<Task> GetAsync(int taskId)
        {
            return await ApiService.Get<Task>($"api/tasks/{taskId}");
        }

        public static async Task<IEnumerable<Task>> GetAsync()
        {
            return await ApiService.Get<IEnumerable<Task>>("api/tasks");
        }

        public static async Task<IEnumerable<Task>> GetByProjectAsync(int projectId)
        {
            return await ApiService.Get<IEnumerable<Task>>($"api/projects/{projectId}/tasks");
        }
    }
}
