using System.Collections.Generic;
using TimesheetManagement.Client.Common.Entities;

namespace TimesheetManagement.Client.Tasks.Entities
{
	public class TaskActivity
	{
		public Task Task { get; set; }

		public ICollection<Activity> Activities { get; set; }
	}
}
