using System.Collections.Generic;
using System.Threading.Tasks;
using TimesheetManagement.Client.Mvc.Common.Services;

namespace TimesheetManagement.Client.Mvc.Tasks.Services
{
	public static class ClientsApiService
	{
        public static async Task<Entities.Client> GetAsync(string clientId)
        {
            return await ApiService.Get<Entities.Client>($"api/clients/{clientId}");
        }

        public static async Task<IEnumerable<Entities.Client>> GetAsync()
        {
            return await ApiService.Get<IEnumerable<Entities.Client>>("api/clients");
        }
    }
}
