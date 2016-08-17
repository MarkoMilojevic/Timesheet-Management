namespace TimesheetManagement.Business.Tasks.Entities.Entities
{
	public class Task
	{
		public int TaskId { get; set; }

		public string Name { get; set; }

		public Account Account { get; set; }

		public Project Project { get; set; }
	}
}
