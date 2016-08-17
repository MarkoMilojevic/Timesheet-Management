using System.Collections.Generic;
using TimesheetManagement.Business.Entities.Entities;

namespace TimesheetManagement.Business.Tasks.Entities.Entities
{
	public class TaskActivity
	{
		public Task Task { get; set; }

		public ICollection<Activity> Activities { get; set; }
	}
}
