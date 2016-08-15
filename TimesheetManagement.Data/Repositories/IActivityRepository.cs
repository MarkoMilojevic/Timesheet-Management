using System.Collections.Generic;
using TimesheetManagement.Business.Entities;

namespace TimesheetManagement.Data.Repositories
{
	public interface IActivityRepository
	{
		Activity GetActivity(int activityId);

		ICollection<Activity> GetActivities(int employeeId);
	}
}
