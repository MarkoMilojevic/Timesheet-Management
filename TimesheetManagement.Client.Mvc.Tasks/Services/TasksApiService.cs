using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TimesheetManagement.Client.Mvc.Common.Entities;
using TimesheetManagement.Client.Mvc.Common.Helpers;
using TimesheetManagement.Client.Mvc.Tasks.Entities;
using TimesheetManagement.Client.Mvc.Tasks.Models;
using Task = TimesheetManagement.Client.Mvc.Tasks.Entities.Task;

namespace TimesheetManagement.Client.Mvc.Tasks.Services
{
	public class TasksApiService
	{
		public async Task<ICollection<TaskActivityModel>> GetTaskActivitiesAsync(int employeeId)
		{
			HttpClient httpClient = TimesheetHttpClient.GetHttpClient();
			HttpResponseMessage response = await httpClient.GetAsync($"api/taskactivities/{employeeId}");
			if (!response.IsSuccessStatusCode)
			{
				return null;
			}

			string responseContent = await response.Content.ReadAsStringAsync();
			return JsonConvert.DeserializeObject<ICollection<TaskActivityModel>>(responseContent);
		}
	}
}
