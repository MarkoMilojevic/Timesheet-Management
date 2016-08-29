using System.Collections.Generic;
using TimesheetManagement.Data.Entities;
using ActivityDTO = TimesheetManagement.Data.Entities.Activity;

namespace TimesheetManagement.Data.Interfaces.Common
{
	public interface IActivityRepository
	{
		Activity GetActivity(int activityId);

		ICollection<Activity> GetActivities(int employeeId);

	    int CreateActivity(ActivityDTO taskActivity);
	}
}
