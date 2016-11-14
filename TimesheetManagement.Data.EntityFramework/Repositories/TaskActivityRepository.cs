﻿using System;
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
        public override int Add(TaskActivityDTO taskActivityDto)
        {
            TaskActivity taskActivity = EfDtoMapper.CreateTaskActivity(taskActivityDto);
            taskActivity = context.TaskActivities.Add(taskActivity);
            context.SaveChanges();
            return taskActivity.ActivityId;
        }

        public override bool Remove(TaskActivityDTO taskActivityDto)
        {
            TaskActivity taskActivity = EfDtoMapper.CreateTaskActivity(taskActivityDto);
            context.TaskActivities.Remove(taskActivity);

            return context.SaveChanges() != 0;
        }

        public override TaskActivityDTO Find(params int[] keys)
        {
            TaskActivity taskActivity = context.TaskActivities
                .Include(ta => ta.Activity)
                .Include(ta => ta.Task)
                .Include(ta => ta.Activity.Employee)
                .Include(ta => ta.Task.Project)
                .Include(ta => ta.Task.Project.Client)
                .SingleOrDefault(ta => ta.TaskId == keys[0] && ta.ActivityId == keys[1]);

            return EfDtoMapper.CreateTaskActivityDto(taskActivity);
        }

        public override IEnumerable<TaskActivityDTO> Find(Expression<Func<TaskActivityDTO, bool>> predicate)
        {
            Expression<Func<TaskActivity, bool>> efPredicate = EfExpressionTransformer<TaskActivityDTO, TaskActivity>.Tranform(predicate);

            return context.TaskActivities
                .Where(efPredicate)
                .Include(ta => ta.Activity)
                .Include(ta => ta.Task)
                .Include(ta => ta.Activity.Employee)
                .Include(ta => ta.Task.Project)
                .Include(ta => ta.Task.Project.Client)
                .Select(EfDtoMapper.CreateTaskActivityDto);
        }

        public override IEnumerable<TaskActivityDTO> FindAll()
        {
            return context.TaskActivities
                .Include(ta => ta.Activity)
                .Include(ta => ta.Task)
                .Include(ta => ta.Activity.Employee)
                .Include(ta => ta.Task.Project)
                .Include(ta => ta.Task.Project.Client)
                .Select(EfDtoMapper.CreateTaskActivityDto);
        }
    }
}