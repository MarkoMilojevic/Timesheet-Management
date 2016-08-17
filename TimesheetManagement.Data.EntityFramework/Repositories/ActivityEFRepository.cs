using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimesheetManagement.Data.EntityFramework.Common;
using TimesheetManagement.Data.EntityFramework.Entities;
using TimesheetManagement.Data.Interfaces.CommonRepositories;
using ActivityDTO = TimesheetManagement.Data.Entities.Activity;

namespace TimesheetManagement.Data.EntityFramework.Repositories
{
    public class ActivityEFRepository : IActivityRepository
    {
        private readonly TimesheetContext context;

        public ActivityEFRepository()
        {
            this.context = new TimesheetContext();
        }
        
        public ActivityDTO GetActivity(int activityId)
        {
            Activity activity = this.context.Activities.Find(activityId);

            return EntityFrameworkAutoMapper.CreateActivity(activity);
        }

        public ICollection<ActivityDTO> GetActivities(int employeeId)
        {
            List<Activity> activities = this.context.Activities.Where(a => a.EmployeeId == employeeId).ToList();

            return activities.Select(EntityFrameworkAutoMapper.CreateActivity).ToList();
        }
    }
}
