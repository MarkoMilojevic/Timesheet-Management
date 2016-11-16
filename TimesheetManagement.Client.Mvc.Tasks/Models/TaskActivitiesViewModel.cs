using PagedList;
using TimesheetManagement.Client.Mvc.Common.Helpers;
using TimesheetManagement.Client.Mvc.Tasks.Entities;

namespace TimesheetManagement.Client.Mvc.Tasks.Models
{
	public class TaskActivitiesViewModel
	{
		public IPagedList<TaskActivity> TaskActivityViewModels { get; set; }

		public PagingInfo PagingInfo { get; set; }
	}
}
