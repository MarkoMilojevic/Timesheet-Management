using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Marvin.JsonPatch;
using TimesheetManagement.Client.Mvc.Common.Services;
using TimesheetManagement.Client.Mvc.Tasks.Entities;

namespace TimesheetManagement.Client.Mvc.Tasks.Services
{
	public static class ProjectsApiService
	{
        private const string ControllerActionUri = "api/projects/";

        public static async Task<Project> GetAsync(int projectId)
        {
            return await ApiService.GetAsync<Project>(ControllerActionUri + projectId);
        }

        public static async Task<IEnumerable<Project>> GetAsync()
        {
            return await ApiService.GetAsync<IEnumerable<Project>>(ControllerActionUri);
        }

        public static async Task<IEnumerable<Project>> GetByClientAsync(string clientId)
        {
            return await ApiService.GetAsync<IEnumerable<Project>>($"api/clients/{clientId}/projects");
        }

        public static async Task<HttpResponseMessage> PatchAsync(int id, Project project)
        {
            JsonPatchDocument<Project> patchDoc = new JsonPatchDocument<Project>();

            patchDoc.Replace(p => p.Name, project.Name);
            patchDoc.Replace(p => p.StartDate, project.StartDate);
            patchDoc.Replace(p => p.EndDate, project.EndDate);

            return await ApiService.PatchAsync(ControllerActionUri + id, patchDoc);
        }
        
        public static async Task<HttpResponseMessage> PutAsync(Project project)
        {
            return await ApiService.PutAsync(ControllerActionUri, project);
        }

        public static async Task<HttpResponseMessage> PostAsync(Project project)
        {
            return await ApiService.PostAsync(ControllerActionUri, project);
        }

        public static async Task<HttpResponseMessage> DeleteAsync(int projectId)
        {
            return await ApiService.DeleteAsync(ControllerActionUri + projectId);
        }
    }
}
