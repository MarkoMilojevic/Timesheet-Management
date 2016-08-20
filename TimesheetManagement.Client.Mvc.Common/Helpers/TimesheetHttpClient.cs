using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace TimesheetManagement.Client.Mvc.Common.Helpers
{
	public static class TimesheetHttpClient
	{
		public static HttpClient GetHttpClient(string requestedVersion = null)
		{
			HttpClient client = new HttpClient();
			client.BaseAddress = new Uri("http://localhost:55674");
			client.DefaultRequestHeaders.Accept.Clear();
			client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

			if (requestedVersion != null)
			{
				client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.timesheetmanagement.v" + requestedVersion + "+json"));
			}

			return client;
		}
	}
}
