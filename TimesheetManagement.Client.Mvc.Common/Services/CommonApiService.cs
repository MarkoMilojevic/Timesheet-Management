using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TimesheetManagement.Client.Mvc.Common.Entities;
using TimesheetManagement.Client.Mvc.Common.Helpers;

namespace TimesheetManagement.Client.Mvc.Common.Services
{
	public class TasksService
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
	}
}
