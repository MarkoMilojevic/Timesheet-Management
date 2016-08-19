using System.Collections.Generic;
using TimesheetManagement.Client.Mvc.Common.Entities;

namespace TimesheetManagement.Client.Mvc.Tasks.Entities
{
	public class TaskActivity
	{
		public Task Task { get; set; }

		public ICollection<Activity> Activities { get; set; }
	}
}
