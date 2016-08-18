using System.Collections.Generic;
using PagedList;
using TimesheetManagement.Business.Tasks.Entities;
using TimesheetManagement.Client.Common.Helpers;

namespace TimesheetManagement.Client.Models
{
	public class TimesheetViewModel
	{
		public IEnumerable<Account> Accounts { get; set; }

		//public PagingInfo PagingInfo { get; set; }
	}
}
