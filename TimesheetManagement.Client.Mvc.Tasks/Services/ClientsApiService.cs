using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Marvin.JsonPatch;
using TimesheetManagement.Client.Mvc.Common.Services;

namespace TimesheetManagement.Client.Mvc.Tasks.Services
{
	public static class ClientsApiService
	{
        private const string ControllerActionUri = "api/clients/";

        public static async Task<Entities.Client> GetAsync(string clientId)
        {
            return await ApiService.GetAsync<Entities.Client>(ControllerActionUri + clientId);
        }

        public static async Task<IEnumerable<Entities.Client>> GetAsync()
        {
            return await ApiService.GetAsync<IEnumerable<Entities.Client>>(ControllerActionUri);
        }
        
        public static async Task<HttpResponseMessage> PatchAsync(string clientId, Entities.Client client)
        {
            JsonPatchDocument<Entities.Client> patchDoc = new JsonPatchDocument<Entities.Client>();

            patchDoc.Replace(c => c.Name, client.Name);
            patchDoc.Replace(c => c.RegisterNumber, client.RegisterNumber);
            patchDoc.Replace(c => c.TaxpayerIdentificationNumber, client.TaxpayerIdentificationNumber);

            return await ApiService.PatchAsync(ControllerActionUri + clientId, patchDoc);
        }

        public static async Task<HttpResponseMessage> PutAsync(Entities.Client client)
        {
            return await ApiService.PutAsync(ControllerActionUri, client);
        }

        public static async Task<HttpResponseMessage> PostAsync(Entities.Client client)
        {
            return await ApiService.PostAsync(ControllerActionUri, client);
        }

        public static async Task<HttpResponseMessage> DeleteAsync(string clientId)
        {
            return await ApiService.DeleteAsync(ControllerActionUri + clientId);
        }
    }
}
