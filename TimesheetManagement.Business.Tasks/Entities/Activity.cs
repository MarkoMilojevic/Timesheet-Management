namespace TimesheetManagement.Business.Tasks.Entities
{
	public class Activity
	{
		public int ActivityId { get; set; }

		public string Name { get; set; }

		public Account Account { get; set; }

		public Project Project { get; set; }
	}
}
