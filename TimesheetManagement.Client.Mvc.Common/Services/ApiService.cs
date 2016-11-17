using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Marvin.JsonPatch;
using Newtonsoft.Json;
using TimesheetManagement.Client.Mvc.Common.Helpers;

namespace TimesheetManagement.Client.Mvc.Common.Services
{
    public static class ApiService
    {
        private const string JsonMediaType = "application/json";

        public static async Task<T> GetAsync<T>(string uri) where T : class
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

        public static async Task<HttpResponseMessage> PatchAsync<T>(string uri, JsonPatchDocument<T> patchDoc) where T : class
        {
            HttpClient httpClient = TimesheetHttpClient.GetHttpClient();

            string json = JsonConvert.SerializeObject(patchDoc);
            StringContent content = new StringContent(json, Encoding.Unicode, JsonMediaType);

            return await httpClient.PatchAsync(uri, content);
        }

        public static async Task<HttpResponseMessage> PutAsync<T>(string uri, T obj) where T : class
        {
            HttpClient httpClient = TimesheetHttpClient.GetHttpClient();

            string json = JsonConvert.SerializeObject(obj);
            StringContent content = new StringContent(json, Encoding.Unicode, JsonMediaType);

            return await httpClient.PutAsync(uri, content);
        }

        public static async Task<HttpResponseMessage> PostAsync<T>(string uri, T obj) where T : class
        {
            HttpClient httpClient = TimesheetHttpClient.GetHttpClient();

            string json = JsonConvert.SerializeObject(obj);
            StringContent content = new StringContent(json, Encoding.Unicode, JsonMediaType);

            return await httpClient.PostAsync(uri, content);
        }

        public static async Task<HttpResponseMessage> DeleteAsync(string uri)
        {
            HttpClient httpClient = TimesheetHttpClient.GetHttpClient();

            return await httpClient.DeleteAsync(uri);
        }
    }
}
