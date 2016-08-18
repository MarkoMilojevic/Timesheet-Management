﻿using System.Collections.Generic;
using TimesheetManagement.Data.Entities;

namespace TimesheetManagement.Data.Interfaces.Common
{
	public interface IActivityRepository
	{
		Activity GetActivity(int activityId);

		ICollection<Activity> GetActivities(int employeeId);
	}
}