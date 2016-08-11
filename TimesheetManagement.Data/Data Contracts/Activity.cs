using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimesheetManagement.Data
{
	public class Activity
	{
		public string Name { get; set; }

		public Client Client { get; set; }

		public Project Project { get; set; }
	}
}
