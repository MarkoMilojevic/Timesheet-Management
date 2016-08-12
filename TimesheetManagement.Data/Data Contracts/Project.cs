using System;
using System.Collections.Generic;


namespace TimesheetManagement.Data.DataContracts
{
	public class Project
	{
		public string Name { get; set; }

		public DateTime StartDate { get; set; }

		public DateTime EndDate { get; set; }

		public Client Client { get; set; }

		public IList<Activity> Activities { get; set; }
	}
}
