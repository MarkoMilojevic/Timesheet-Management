using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using TimesheetManagement.Data.EntityFramework.Entities;
using TimesheetManagement.Data.EntityFramework.Helpers;
using ActivityDTO = TimesheetManagement.Data.Entities.Activity;

namespace TimesheetManagement.Data.EntityFramework.Repositories
{
    public class ActivityRepository : EfRepository<ActivityDTO, int>
    {
        public override int Add(ActivityDTO activityDto)
        {
            Activity activity = EfDtoMapper.CreateActivity(activityDto);
            activity = context.Activities.Add(activity);
            context.SaveChanges();

            return activity.ActivityId;
        }

        public override bool Remove(ActivityDTO activityDto)
        {
            Activity activity = EfDtoMapper.CreateActivity(activityDto);
            context.Activities.Remove(activity);

            return context.SaveChanges() != 0;
        }

        public override ActivityDTO Find(params int[] keys)
        {
            Activity activity = context.Activities
                .Include(a => a.Employee)
                .SingleOrDefault(a => a.ActivityId == keys[0]);

            return EfDtoMapper.CreateActivityDto(activity);
        }

        public override IEnumerable<ActivityDTO> Find(Expression<Func<ActivityDTO, bool>> predicate)
        {
            Expression<Func<Activity, bool>> efPredicate = EfExpressionTransformer<ActivityDTO, Activity>.Tranform(predicate);

            return context.Activities
                .Where(efPredicate)
                .Include(a => a.Employee)
                .Select(EfDtoMapper.CreateActivityDto);
        }

        public override IEnumerable<ActivityDTO> FindAll()
        {
            return context.Activities
                .Include(a => a.Employee)
                .Select(EfDtoMapper.CreateActivityDto);
        }
    }
}