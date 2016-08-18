﻿using System;
using System.Collections.Generic;

namespace TimesheetManagement.Business.Tasks.Entities.Entities
{
	public class Project
	{
		public int ProjectId { get; set; }

		public string Name { get; set; }

		public DateTime StartDate { get; set; }

		public DateTime EndDate { get; set; }

		public Account Account { get; set; }

		public ICollection<Task> Tasks { get; set; }
	}
}