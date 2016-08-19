using System.Collections.Generic;
using TimesheetManagement.Client.Mvc.Tasks.Entities;

namespace TimesheetManagement.Client.Mvc.Models
{
	public class TimesheetViewModel
	{
		public IEnumerable<Account> Accounts { get; set; }

		//public PagingInfo PagingInfo { get; set; }
	}
}
