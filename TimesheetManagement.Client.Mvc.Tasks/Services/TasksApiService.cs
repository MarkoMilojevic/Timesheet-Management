using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Marvin.JsonPatch;
using TimesheetManagement.Client.Mvc.Common.Services;
using Task = TimesheetManagement.Client.Mvc.Tasks.Entities.Task;

namespace TimesheetManagement.Client.Mvc.Tasks.Services
{
	public static class TasksApiService
	{
        private const string ControllerActionUri = "api/tasks/";

        public static async Task<Task> GetAsync(int taskId)
        {
            return await ApiService.GetAsync<Task>(ControllerActionUri + taskId);
        }

        public static async Task<IEnumerable<Task>> GetAsync()
        {
            return await ApiService.GetAsync<IEnumerable<Task>>(ControllerActionUri);
        }

        public static async Task<IEnumerable<Task>> GetByProjectAsync(int projectId)
        {
            return await ApiService.GetAsync<IEnumerable<Task>>($"api/projects/{projectId}/tasks");
        }

        public static async Task<HttpResponseMessage> PatchAsync(int projectId, Task task)
        {
            JsonPatchDocument<Task> patchDoc = new JsonPatchDocument<Task>();

            patchDoc.Replace(t => t.Name, task.Name);

            return await ApiService.PatchAsync(ControllerActionUri + projectId, patchDoc);
        }

        public static async Task<HttpResponseMessage> PutAsync(Task task)
        {
            return await ApiService.PutAsync(ControllerActionUri, task);
        }

        public static async Task<HttpResponseMessage> PostAsync(Task task)
        {
            return await ApiService.PostAsync(ControllerActionUri, task);
        }

        public static async Task<HttpResponseMessage> DeleteAsync(int taskId)
        {
            return await ApiService.DeleteAsync(ControllerActionUri + taskId);
        }
    }
}
