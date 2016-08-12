using System.Collections.Generic;


namespace TimesheetManagement.Data.DataContracts
{
	public class Client
	{
		public string Name { get; set; }

		public string RegisterNumber { get; set; }

		public string TaxpayerIdentificationNumber { get; set; }

		public IList<Project> Projects { get; set; }
	}
}
