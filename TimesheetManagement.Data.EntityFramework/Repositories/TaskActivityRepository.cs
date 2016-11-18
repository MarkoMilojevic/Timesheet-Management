using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using TimesheetManagement.Data.EntityFramework.Entities;
using TimesheetManagement.Data.EntityFramework.Helpers;
using TaskActivityDTO = TimesheetManagement.Data.Tasks.Entities.TaskActivity;

namespace TimesheetManagement.Data.EntityFramework.Repositories
{
    public class TaskActivityRepository : EfRepository<TaskActivityDTO, int>
    {
        public override TaskActivityDTO Add(TaskActivityDTO taskActivityDto)
        {
            TaskActivity taskActivity = EfDtoMapper.CreateTaskActivity(taskActivityDto);

            taskActivity = context.TaskActivities.Add(taskActivity);
            context.SaveChanges();

            return EfDtoMapper.CreateTaskActivityDto(taskActivity);
        }

        public override bool Remove(TaskActivityDTO taskActivityDto)
        {
            TaskActivity taskActivity = context.TaskActivities.Local.FirstOrDefault(ta => ta.TaskId == taskActivityDto.Task.TaskId && ta.ActivityId == taskActivityDto.Activity.ActivityId);
            if (taskActivity == null)
            {
                taskActivity = EfDtoMapper.CreateTaskActivity(taskActivityDto);
                context.TaskActivities.Attach(taskActivity);
            }

            context.TaskActivities.Remove(taskActivity);

            return context.SaveChanges() != 0;
        }

        public override bool Update(TaskActivityDTO taskActivityDto)
        {
            TaskActivity existingTaskActivity = context.TaskActivities.FirstOrDefault(ta => ta.TaskId == taskActivityDto.Task.TaskId && ta.ActivityId == taskActivityDto.Activity.ActivityId);
            if (existingTaskActivity == null)
            {
                return false;
            }

            context.Entry(existingTaskActivity).State = EntityState.Detached;

            TaskActivity updatedTaskActivity = EfDtoMapper.CreateTaskActivity(taskActivityDto);
            context.TaskActivities.Attach(updatedTaskActivity);
            context.Entry(updatedTaskActivity).State = EntityState.Modified;

            return context.SaveChanges() != 0;
        }

        public override TaskActivityDTO Find(params int[] keys)
        {
            int taskId = keys[0];
            int activityId = keys[1];

            TaskActivity taskActivity = context.TaskActivities
                .Include(ta => ta.Activity.Employee)
                .Include(ta => ta.Task.Project.Client)
                .SingleOrDefault(ta => ta.TaskId == taskId && ta.ActivityId == activityId);

            return EfDtoMapper.CreateTaskActivityDto(taskActivity);
        }

        public override IEnumerable<TaskActivityDTO> Find(Expression<Func<TaskActivityDTO, bool>> predicate)
        {
            Expression<Func<TaskActivity, bool>> efPredicate = EfExpressionTransformer<TaskActivityDTO, TaskActivity>.Tranform(predicate);

            return context.TaskActivities
                .Where(efPredicate)
                .Include(ta => ta.Activity.Employee)
                .Include(ta => ta.Task.Project.Client)
                .Select(EfDtoMapper.CreateTaskActivityDto);
        }

        public override IEnumerable<TaskActivityDTO> FindAll()
        {
            return context.TaskActivities
                .Include(ta => ta.Activity.Employee)
                .Include(ta => ta.Task.Project.Client)
                .Select(EfDtoMapper.CreateTaskActivityDto);
        }
    }
}
