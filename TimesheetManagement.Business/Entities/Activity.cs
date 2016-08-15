using System;

namespace TimesheetManagement.Business.Entities
{
	public class Activity
	{
		public int ActivityId { get; set; }

		public DateTime StartDate { get; set; }

		public DateTime EndDate { get; set; }

		public int DurationInHours { get; set; }

		public string Description { get; set; }

		public bool IsApproved { get; set; }
	}
}
