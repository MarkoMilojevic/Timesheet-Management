﻿using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TimesheetManagement.Client.Mvc.Common.Helpers;
using TimesheetManagement.Client.Mvc.Tasks.Entities;
using Task = TimesheetManagement.Client.Mvc.Tasks.Entities.Task;

namespace TimesheetManagement.Client.Mvc.Tasks.Services
{
	public class TasksApiService
	{
        public async Task<ICollection<Entities.Client>> GetAccountsAsync()
        {
            HttpClient httpClient = TimesheetHttpClient.GetHttpClient();
            HttpResponseMessage response = await httpClient.GetAsync("api/clients");
            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            string responseContent = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<ICollection<Entities.Client>>(responseContent);
        }

        public async Task<ICollection<Project>> GetProjectsAsync(string clientId)
        {
            HttpClient httpClient = TimesheetHttpClient.GetHttpClient();
            HttpResponseMessage response = await httpClient.GetAsync($"api/clients/{clientId}/projects");
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

        public async Task<ICollection<TaskActivity>> GetTaskActivitiesAsync(int employeeId)
		{
			HttpClient httpClient = TimesheetHttpClient.GetHttpClient();
			HttpResponseMessage response = await httpClient.GetAsync($"api/employees/{employeeId}/taskactivities");
			if (!response.IsSuccessStatusCode)
			{
				return null;
			}

			string responseContent = await response.Content.ReadAsStringAsync();
			return JsonConvert.DeserializeObject<ICollection<TaskActivity>>(responseContent);
		}

	    public async Task<HttpResponseMessage> CreateTaskActivityAsync(TaskActivity taskActivity)
	    {
            HttpClient httpClient = TimesheetHttpClient.GetHttpClient();
            string serializedTaskActivity = JsonConvert.SerializeObject(taskActivity);

            return await httpClient.PostAsync("api/taskactivities/", new StringContent(serializedTaskActivity, System.Text.Encoding.Unicode, "application/json"));
        }
    }
}
