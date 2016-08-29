using System.Collections.Generic;
using System.Linq;
using TimesheetManagement.Data.EntityFramework.Entities;
using TimesheetManagement.Data.EntityFramework.Helpers;
using TimesheetManagement.Data.Interfaces.Common;
using ActivityDTO = TimesheetManagement.Data.Entities.Activity;

namespace TimesheetManagement.Data.EntityFramework.Repositories
{
	public class ActivityRepository : IActivityRepository
	{
		private readonly TimesheetContext context;

		public ActivityRepository()
		{
			this.context = new TimesheetContext();
		}

		public ActivityDTO GetActivity(int activityId)
		{
			Activity activity = this.context.Activities.Find(activityId);

			return EfDtoMapper.CreateActivityDto(activity);
		}

		public ICollection<ActivityDTO> GetActivities(int employeeId)
		{
			List<Activity> activities = this.context.Activities.Where(a => a.EmployeeId == employeeId).ToList();

			return activities.Select(EfDtoMapper.CreateActivityDto).ToList();
		}

        public int CreateActivity(ActivityDTO activity)
        {
            Activity act = EfDtoMapper.CreateActivity(activity);
            act = this.context.Activities.Add(act);
            this.context.SaveChanges();
            return act.ActivityId;
        }
    }
}
