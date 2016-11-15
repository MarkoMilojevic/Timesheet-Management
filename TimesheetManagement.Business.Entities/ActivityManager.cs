using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using TimesheetManagement.Business.Entities;
using TimesheetManagement.Business.Helpers;
using TimesheetManagement.Business.Interfaces;
using TimesheetManagement.Data.Interfaces;
using ActivityDTO = TimesheetManagement.Data.Entities.Activity;

namespace TimesheetManagement.Business.Managers
{
    public class ActivityManager : IManager<Activity, int>
    {
        private readonly IRepository<ActivityDTO, int> activityRepository;

        public ActivityManager(IRepository<ActivityDTO, int> activityRepository)
        {
            this.activityRepository = activityRepository;
        }

        public int Add(Activity activity)
        {
            ActivityDTO activityDto = CoreBoMapper.CreateActivityDto(activity);

            return activityRepository.Add(activityDto);
        }

        public bool Remove(Activity activity)
        {
            ActivityDTO activityDto = CoreBoMapper.CreateActivityDto(activity);

            return activityRepository.Remove(activityDto);
        }

        public Activity Find(params int[] keys)
        {
            ActivityDTO activityDto = activityRepository.Find(keys);

            return CoreBoMapper.CreateActivity(activityDto);
        }

        public IEnumerable<Activity> Find(Expression<Func<Activity, bool>> predicate)
        {
            Expression<Func<ActivityDTO, bool>> dataPredicate = CoreExpressionTransformer<Activity, ActivityDTO>.Tranform(predicate);

            return activityRepository.Find(dataPredicate).Select(CoreBoMapper.CreateActivity);
        }

        public IEnumerable<Activity> FindAll()
        {
            return activityRepository.FindAll().Select(CoreBoMapper.CreateActivity);
        }
    }
}