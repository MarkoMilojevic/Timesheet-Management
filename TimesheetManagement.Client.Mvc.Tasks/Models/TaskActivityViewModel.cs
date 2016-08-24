using PagedList;
using TimesheetManagement.Client.Mvc.Common.Helpers;

namespace TimesheetManagement.Client.Mvc.Tasks.Models
{
	public class TaskActivityViewModel
	{
		public IPagedList<TaskActivityModel> TaskActivityModels { get; set; }

		public PagingInfo PagingInfo { get; set; }
	}
}
