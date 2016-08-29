using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TimesheetManagement.Client.Mvc.Common.Helpers;
using TimesheetManagement.Client.Mvc.Tasks.Entities;
using TimesheetManagement.Client.Mvc.Tasks.Models;
using Task = TimesheetManagement.Client.Mvc.Tasks.Entities.Task;

namespace TimesheetManagement.Client.Mvc.Tasks.Services
{
	public class TasksApiService
	{
        public async Task<ICollection<Account>> GetAccountsAsync()
        {
            HttpClient httpClient = TimesheetHttpClient.GetHttpClient();
            HttpResponseMessage response = await httpClient.GetAsync("api/accounts");
            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            string responseContent = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<ICollection<Account>>(responseContent);
        }

        public async Task<ICollection<Project>> GetProjectsAsync(string accountId)
        {
            HttpClient httpClient = TimesheetHttpClient.GetHttpClient();
            HttpResponseMessage response = await httpClient.GetAsync($"api/accounts/{accountId}/projects");
            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            string responseContent = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<ICollection<Project>>(responseContent);
        }

        public async Task<ICollection<Task>> GetTasksAsync(int projectId)
        {
            HttpClient httpClient = TimesheetHttpClient.GetHttpClient();
            HttpResponseMessage response = await httpClient.GetAsync($"api/projects/{projectId}/tasks");
            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            string responseContent = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<ICollection<Task>>(responseContent);
        }

        public async Task<ICollection<TaskActivityViewModel>> GetTaskActivitiesAsync(int employeeId)
		{
			HttpClient httpClient = TimesheetHttpClient.GetHttpClient();
			HttpResponseMessage response = await httpClient.GetAsync($"api/taskactivities/{employeeId}");
			if (!response.IsSuccessStatusCode)
			{
				return null;
			}

			string responseContent = await response.Content.ReadAsStringAsync();
			return JsonConvert.DeserializeObject<ICollection<TaskActivityViewModel>>(responseContent);
		}

	    public async Task<HttpResponseMessage> CreateTaskActivityAsync(TaskActivity taskActivity)
	    {
            HttpClient httpClient = TimesheetHttpClient.GetHttpClient();
            string serializedTaskActivity = JsonConvert.SerializeObject(taskActivity);

            return await httpClient.PostAsync("api/taskactivities/", new StringContent(serializedTaskActivity, System.Text.Encoding.Unicode, "application/json"));
        }
    }
}
