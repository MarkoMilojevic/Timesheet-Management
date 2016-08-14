using PagedList;
using TimesheetManagement.Business.Entities;
using TimesheetManagement.Business.Helpers;

namespace TimesheetManagement.Client.Models
{
	public class TimesheetViewModel
	{
		public IPagedList<EmployeeActivity> EmployeeActivities { get; set; }

		public PagingInfo PagingInfo { get; set; }
	}
}
