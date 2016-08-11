using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimesheetManagement.Data
{
	public class Client
	{
		public string Name { get; set; }

		public string RegisterNumber { get; set; }

		public string TaxpayerIdentificationNumber { get; set; }

		public IList<Project> Projects { get; set; }
	}
}
