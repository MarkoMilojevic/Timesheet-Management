using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TimesheetManagement.Client.Mvc.Common.Helpers;

namespace TimesheetManagement.Client.Mvc.Common.Services
{
	public static class ApiService
	{
        public static async Task<T> Get<T>(string uri) where T : class
        {
            HttpClient httpClient = TimesheetHttpClient.GetHttpClient();

            HttpResponseMessage response = await httpClient.GetAsync(uri);
            if (!response.IsSuccessStatusCode)
            {
                return default(T);
            }

            string responseContent = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<T>(responseContent);
        }

        public static async Task<HttpResponseMessage> PostAsync<T>(string uri, T obj)
        {
            HttpClient httpClient = TimesheetHttpClient.GetHttpClient();

            string json = JsonConvert.SerializeObject(obj);
            StringContent content = new StringContent(json, System.Text.Encoding.Unicode, "application/json");

            return await httpClient.PostAsync(uri, content);
        }
    }
}
