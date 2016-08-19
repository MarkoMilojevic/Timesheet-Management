using System.Collections.Generic;

namespace TimesheetManagement.Client.Mvc.Tasks.Entities
{
	public class Account
	{
		public string Name { get; set; }

		public string RegisterNumber { get; set; }

		public string TaxpayerIdentificationNumber { get; set; }

		public ICollection<Project> Projects { get; set; }
	}
}
