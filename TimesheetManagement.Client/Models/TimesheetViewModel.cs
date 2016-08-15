using PagedList;
using TimesheetManagement.Business.Tasks.Entities;
using TimesheetManagement.Client.Helpers;

namespace TimesheetManagement.Client.Models
{
	public class TimesheetViewModel
	{
		public IPagedList<EmployeeActivity> EmployeeActivities { get; set; }

		public PagingInfo PagingInfo { get; set; }
	}
}
