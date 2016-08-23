using PagedList;
using TimesheetManagement.Client.Mvc.Common.Helpers;
using TimesheetManagement.Client.Mvc.Tasks.Entities;

namespace TimesheetManagement.Client.Mvc.Tasks.Models
{
	public class TaskActivityViewModel
	{
		public IPagedList<Account> Accounts { get; set; }

		public PagingInfo PagingInfo { get; set; }
	}
}
