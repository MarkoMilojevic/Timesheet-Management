using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TimesheetManagement.Business.Tasks.Entities;
using TimesheetManagement.Client.Helpers;
using TimesheetManagement.Service;

namespace TimesheetManagement.Client.Services
{
    public class ApiTimesheetService : ITimesheetService
    {
        public async Task<Account> GetAccountAsync(string tin)
        {
            HttpClient httpClient = TimesheetHttpClient.GetHttpClient();
            HttpResponseMessage response = await httpClient.GetAsync($"api/clients/{tin}");
            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            string responseContent = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Account>(responseContent);
        }

        public async Task<ICollection<Account>> GetAccountsAsync()
        {
            HttpClient httpClient = TimesheetHttpClient.GetHttpClient();
            HttpResponseMessage response = await httpClient.GetAsync("api/clients");
            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            string responseContent = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<ICollection<Account>>(responseContent);
        }

        public async Task<Project> GetProjectAsync(int id)
        {
            HttpClient httpClient = TimesheetHttpClient.GetHttpClient();
            HttpResponseMessage response = await httpClient.GetAsync($"api/projects/{id}");
            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            string responseContent = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Project>(responseContent);
        }

        public async Task<ICollection<Project>> GetProjectsAsync()
        {
            HttpClient httpClient = TimesheetHttpClient.GetHttpClient();
            HttpResponseMessage response = await httpClient.GetAsync("api/clients");
            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            string responseContent = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<ICollection<Project>>(responseContent);
        }

        public async Task<Activity> GetActivityAsync(int id)
        {
            HttpClient httpClient = TimesheetHttpClient.GetHttpClient();
            HttpResponseMessage response = await httpClient.GetAsync($"api/activities/{id}");
            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            string responseContent = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Activity>(responseContent);
        }

        public async Task<ICollection<Activity>> GetActivitiesAsync(int projectId)
        {
            HttpClient httpClient = TimesheetHttpClient.GetHttpClient();
            HttpResponseMessage response = await httpClient.GetAsync("api/activities");
            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            string responseContent = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<ICollection<Activity>>(responseContent);
        }

        public async Task<Employee> GetEmployeeAsync(int id)
        {
            HttpClient httpClient = TimesheetHttpClient.GetHttpClient();
            HttpResponseMessage response = await httpClient.GetAsync($"api/employees/{id}");
            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            string responseContent = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Employee>(responseContent);
        }

        public async Task<Employee> GetEmployeeAsync(string email)
        {
            HttpClient httpClient = TimesheetHttpClient.GetHttpClient();
            HttpResponseMessage response = await httpClient.GetAsync($"api/employees/{email}");
            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            string responseContent = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Employee>(responseContent);
        }

        public async Task<ICollection<Employee>> GetEmployeesAsync()
        {
            HttpClient httpClient = TimesheetHttpClient.GetHttpClient();
            HttpResponseMessage response = await httpClient.GetAsync("api/employees");
            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            string responseContent = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<ICollection<Employee>>(responseContent);
        }

        public async Task<ICollection<EmployeeActivity>> GetEmployeeActivitiesAsync(int employeeId)
        {
            HttpClient httpClient = TimesheetHttpClient.GetHttpClient();
            HttpResponseMessage response = await httpClient.GetAsync($"api/employeeactivities/{employeeId}");
            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            string responseContent = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<ICollection<EmployeeActivity>>(responseContent);
        }
    }
}
