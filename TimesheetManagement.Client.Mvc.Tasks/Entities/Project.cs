using System;
using System.Collections.Generic;

namespace TimesheetManagement.Client.Mvc.Tasks.Entities
{
	public class Project
	{
		public int ProjectId { get; set; }

		public string Name { get; set; }

		public DateTime StartDate { get; set; }

		public DateTime EndDate { get; set; }

		public int AccountId { get; set; }
	}
}
