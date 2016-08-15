using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;
using TimesheetManagement.Business.Tasks.Entities;
using TimesheetManagement.Client.Helpers;
using TimesheetManagement.Service;
namespace TimesheetManagement.Client.Managers
{
	public class WebApiTimesheetManager : ITimesheetService
	{
		public Account GetClient(string tin)
		{
			HttpClient httpClient = TimesheetHttpClient.GetClient();
			HttpResponseMessage response = httpClient.GetAsync($"api/clients/{tin}").GetAwaiter().GetResult();
			if (!response.IsSuccessStatusCode)
			{
				return null;
			}

			string responseContent = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
			return JsonConvert.DeserializeObject<Account>(responseContent);
		}

		public ICollection<Account> GetClients()
		{
			HttpClient httpClient = TimesheetHttpClient.GetClient();
			HttpResponseMessage response = httpClient.GetAsync("api/clients").GetAwaiter().GetResult();
			if (!response.IsSuccessStatusCode)
			{
				return null;
			}

			string responseContent = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
			return JsonConvert.DeserializeObject<ICollection<Account>>(responseContent);
		}

		public Project GetProject(int id)
		{
			HttpClient httpClient = TimesheetHttpClient.GetClient();
			HttpResponseMessage response = httpClient.GetAsync($"api/projects/{id}").GetAwaiter().GetResult();
			if (!response.IsSuccessStatusCode)
			{
				return null;
			}

			string responseContent = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
			return JsonConvert.DeserializeObject<Project>(responseContent);
		}

		public ICollection<Project> GetProjects()
		{
			HttpClient httpClient = TimesheetHttpClient.GetClient();
			HttpResponseMessage response = httpClient.GetAsync("api/clients").GetAwaiter().GetResult();
			if (!response.IsSuccessStatusCode)
			{
				return null;
			}

			string responseContent = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
			return JsonConvert.DeserializeObject<ICollection<Project>>(responseContent);
		}

		public Activity GetActivity(int id)
		{
			HttpClient httpClient = TimesheetHttpClient.GetClient();
			HttpResponseMessage response = httpClient.GetAsync($"api/activities/{id}").GetAwaiter().GetResult();
			if (!response.IsSuccessStatusCode)
			{
				return null;
			}

			string responseContent = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
			return JsonConvert.DeserializeObject<Activity>(responseContent);
		}

		public ICollection<Activity> GetActivities(int projectId)
		{
			HttpClient httpClient = TimesheetHttpClient.GetClient();
			HttpResponseMessage response = httpClient.GetAsync("api/activities").GetAwaiter().GetResult();
			if (!response.IsSuccessStatusCode)
			{
				return null;
			}

			string responseContent = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
			return JsonConvert.DeserializeObject<ICollection<Activity>>(responseContent);
		}

		public Employee GetEmployee(int id)
		{
			HttpClient httpClient = TimesheetHttpClient.GetClient();
			HttpResponseMessage response = httpClient.GetAsync($"api/employees/{id}").GetAwaiter().GetResult();
			if (!response.IsSuccessStatusCode)
			{
				return null;
			}

			string responseContent = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
			return JsonConvert.DeserializeObject<Employee>(responseContent);
		}

		public Employee GetEmployee(string email)
		{
			HttpClient httpClient = TimesheetHttpClient.GetClient();
			HttpResponseMessage response = httpClient.GetAsync($"api/employees/{email}").GetAwaiter().GetResult();
			if (!response.IsSuccessStatusCode)
			{
				return null;
			}

			string responseContent = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
			return JsonConvert.DeserializeObject<Employee>(responseContent);
		}

		public ICollection<Employee> GetEmployees()
		{
			HttpClient httpClient = TimesheetHttpClient.GetClient();
			HttpResponseMessage response = httpClient.GetAsync("api/employees").GetAwaiter().GetResult();
			if (!response.IsSuccessStatusCode)
			{
				return null;
			}

			string responseContent = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
			return JsonConvert.DeserializeObject<ICollection<Employee>>(responseContent);
		}

		public ICollection<EmployeeActivity> GetEmployeeActivities(int employeeId)
		{
			HttpClient httpClient = TimesheetHttpClient.GetClient();
			HttpResponseMessage response = httpClient.GetAsync($"api/employeeactivities/{employeeId}").GetAwaiter().GetResult();
			if (!response.IsSuccessStatusCode)
			{
				return null;
			}

			string responseContent = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
			return JsonConvert.DeserializeObject<ICollection<EmployeeActivity>>(responseContent);
		}
	}
}
