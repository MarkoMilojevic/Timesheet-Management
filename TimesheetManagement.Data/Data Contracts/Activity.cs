namespace TimesheetManagement.Data.DataContracts
{
	public class Activity
	{
		public string Name { get; set; }

		public Client Client { get; set; }

		public Project Project { get; set; }
	}
}
