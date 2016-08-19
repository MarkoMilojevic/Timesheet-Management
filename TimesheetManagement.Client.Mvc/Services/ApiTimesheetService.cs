using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TimesheetManagement.Client.Mvc.Common.Entities;
using TimesheetManagement.Client.Mvc.Common.Helpers;
using TimesheetManagement.Client.Mvc.Tasks.Entities;
using Task = TimesheetManagement.Client.Mvc.Tasks.Entities.Task;

namespace TimesheetManagement.Client.Mvc.Services
{
	public class ApiTimesheetService
	{
		public async Task<Employee> GetEmployeeAsync(int employeeId)
		{
			HttpClient httpClient = TimesheetHttpClient.GetHttpClient();
			HttpResponseMessage response = await httpClient.GetAsync($"api/employees/{employeeId}");
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

		public async Task<Activity> GetActivityAsync(int activityId)
		{
			HttpClient httpClient = TimesheetHttpClient.GetHttpClient();
			HttpResponseMessage response = await httpClient.GetAsync($"api/activities/{activityId}");
			if (!response.IsSuccessStatusCode)
			{
				return null;
			}

			string responseContent = await response.Content.ReadAsStringAsync();
			return JsonConvert.DeserializeObject<Activity>(responseContent);
		}

		public async Task<ICollection<Activity>> GetActivitiesAsync(int employeeId)
		{
			HttpClient httpClient = TimesheetHttpClient.GetHttpClient();
			HttpResponseMessage response = await httpClient.GetAsync($"api/employees/{employeeId}/activities");
			if (!response.IsSuccessStatusCode)
			{
				return null;
			}

			string responseContent = await response.Content.ReadAsStringAsync();
			return JsonConvert.DeserializeObject<ICollection<Activity>>(responseContent);
		}

		public async Task<Account> GetAccountAsync(string tin)
		{
			HttpClient httpClient = TimesheetHttpClient.GetHttpClient();
			HttpResponseMessage response = await httpClient.GetAsync($"api/accounts/{tin}");
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
			HttpResponseMessage response = await httpClient.GetAsync("api/accounts");
			if (!response.IsSuccessStatusCode)
			{
				return null;
			}

			string responseContent = await response.Content.ReadAsStringAsync();
			return JsonConvert.DeserializeObject<ICollection<Account>>(responseContent);
		}

		public async Task<Project> GetProjectAsync(int projectId)
		{
			HttpClient httpClient = TimesheetHttpClient.GetHttpClient();
			HttpResponseMessage response = await httpClient.GetAsync($"api/projects/{projectId}");
			if (!response.IsSuccessStatusCode)
			{
				return null;
			}

			string responseContent = await response.Content.ReadAsStringAsync();
			return JsonConvert.DeserializeObject<Project>(responseContent);
		}

		public async Task<ICollection<Project>> GetProjectsAsync(string accountTin)
		{
			HttpClient httpClient = TimesheetHttpClient.GetHttpClient();
			HttpResponseMessage response = await httpClient.GetAsync($"api/accounts/{accountTin}/projects");
			if (!response.IsSuccessStatusCode)
			{
				return null;
			}

			string responseContent = await response.Content.ReadAsStringAsync();
			return JsonConvert.DeserializeObject<ICollection<Project>>(responseContent);
		}

		public async Task<Task> GetTaskAsync(int taskId)
		{
			HttpClient httpClient = TimesheetHttpClient.GetHttpClient();
			HttpResponseMessage response = await httpClient.GetAsync($"api/tasks/{taskId}");
			if (!response.IsSuccessStatusCode)
			{
				return null;
			}

			string responseContent = await response.Content.ReadAsStringAsync();
			return JsonConvert.DeserializeObject<Task>(responseContent);
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

		public async Task<ICollection<TaskActivity>> GetTaskActivitiesAsync(int taskId)
		{
			HttpClient httpClient = TimesheetHttpClient.GetHttpClient();
			HttpResponseMessage response = await httpClient.GetAsync($"api/taskactivities/{taskId}");
			if (!response.IsSuccessStatusCode)
			{
				return null;
			}

			string responseContent = await response.Content.ReadAsStringAsync();
			return JsonConvert.DeserializeObject<ICollection<TaskActivity>>(responseContent);
		}

	    public async Task<ICollection<TaskActivity>> GetTaskActivitiesAsync(int taskId, int employeeId)
	    {
            HttpClient httpClient = TimesheetHttpClient.GetHttpClient();
            HttpResponseMessage response = await httpClient.GetAsync($"api/taskactivities/taskId={taskId},employeeId={employeeId}");
            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            string responseContent = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<ICollection<TaskActivity>>(responseContent);
        }
	}
}
