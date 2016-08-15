using System.Collections.Generic;
using TimesheetManagement.Business.Entities;

namespace TimesheetManagement.Business.Tasks.Entities
{
	public class Task
	{
		public int TaskId { get; set; }

		public string Name { get; set; }

		public Account Account { get; set; }

		public Project Project { get; set; }

		public ICollection<Activity> Activities { get; set; }
	}
}
