namespace TimesheetManagement.Business.Entities
{
	public class Activity
	{
		public int ActivityId { get; set; }

		public string Name { get; set; }

		public Client Client { get; set; }

		public Project Project { get; set; }
	}
}
