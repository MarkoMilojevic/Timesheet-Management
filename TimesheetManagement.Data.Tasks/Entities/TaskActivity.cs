using TimesheetManagement.Data.Entities;

namespace TimesheetManagement.Data.Tasks.Entities
{
	public class TaskActivity
	{
        public Task Task { get; set; }

		public Activity Activity { get; set; }
	}
}
