using System.Collections.Generic;
using PagedList;
using TimesheetManagement.Client.Common.Helpers;
using TimesheetManagement.Client.Tasks.Entities;

namespace TimesheetManagement.Client.Models
{
	public class TimesheetViewModel
	{
		public IEnumerable<Account> Accounts { get; set; }

		//public PagingInfo PagingInfo { get; set; }
	}
}
