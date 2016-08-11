using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimesheetManagement.Data
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
