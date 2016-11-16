using System.Collections.Generic;
using System.Threading.Tasks;
using TimesheetManagement.Client.Mvc.Common.Services;
using TimesheetManagement.Client.Mvc.Tasks.Entities;

namespace TimesheetManagement.Client.Mvc.Tasks.Services
{
	public static class ProjectsApiService
	{
        public static async Task<Project> GetAsync(int projectId)
        {
            return await ApiService.Get<Project>($"api/projects/{projectId}");
        }

        public static async Task<IEnumerable<Project>> GetAsync()
        {
            return await ApiService.Get<IEnumerable<Project>>("api/projects");
        }

        public static async Task<IEnumerable<Project>> GetByClientAsync(string clientId)
        {
            return await ApiService.Get<IEnumerable<Project>>($"api/clients/{clientId}/projects");
        }
    }
}
