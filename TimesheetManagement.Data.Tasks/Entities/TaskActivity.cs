using System.Collections.Generic;
using TimesheetManagement.Data.Entities;

namespace TimesheetManagement.Data.Tasks.Entities
{
	public class TaskActivity
	{
		public Task Task { get; set; }

		public ICollection<Activity> Activities { get; set; }
	}
}
