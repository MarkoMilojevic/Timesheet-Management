using PagedList;
using TimesheetManagement.Client.Mvc.Common.Helpers;

namespace TimesheetManagement.Client.Mvc.Tasks.Models
{
	public class TaskActivitiesViewModel
	{
		public IPagedList<TaskActivityViewModel> TaskActivityViewModels { get; set; }

		public PagingInfo PagingInfo { get; set; }
	}
}
