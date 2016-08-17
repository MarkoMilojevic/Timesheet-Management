using PagedList;
using TimesheetManagement.Business.Tasks.Entities.Entities;
using TimesheetManagement.Client.Common.Helpers;

namespace TimesheetManagement.Client.Models
{
	public class TimesheetViewModel
	{
		public IPagedList<TaskActivity> TaskActivities { get; set; }

		public PagingInfo PagingInfo { get; set; }
	}
}
