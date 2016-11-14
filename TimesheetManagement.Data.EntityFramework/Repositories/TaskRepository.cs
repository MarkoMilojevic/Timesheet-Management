﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using TimesheetManagement.Data.EntityFramework.Entities;
using TimesheetManagement.Data.EntityFramework.Helpers;
using TaskDTO = TimesheetManagement.Data.Tasks.Entities.Task;

namespace TimesheetManagement.Data.EntityFramework.Repositories
{
    public class TaskRepository : EfRepository<TaskDTO, int>
    {
        public override int Add(TaskDTO taskDto)
        {
            Task task = EfDtoMapper.CreateTask(taskDto);
            task = context.Tasks.Add(task);
            context.SaveChanges();

            return task.TaskId;
        }

        public override bool Remove(TaskDTO taskDto)
        {
            Task task = EfDtoMapper.CreateTask(taskDto);
            context.Tasks.Remove(task);

            return context.SaveChanges() != 0;
        }

        public override TaskDTO Find(params int[] keys)
        {
            Task task = context.Tasks
                .Include(t => t.Project)
                .SingleOrDefault(t => t.TaskId == keys[0]);

            return EfDtoMapper.CreateTaskDto(task);
        }

        public override IEnumerable<TaskDTO> Find(Expression<Func<TaskDTO, bool>> predicate)
        {
            Expression<Func<Task, bool>> efPredicate = EfExpressionTransformer<TaskDTO, Task>.Tranform(predicate);

            return context.Tasks
                .Where(efPredicate)
                .Include(t => t.Project)
                .Select(EfDtoMapper.CreateTaskDto);
        }

        public override IEnumerable<TaskDTO> FindAll()
        {
            return context.Tasks
                .Include(t => t.Project)
                .Select(EfDtoMapper.CreateTaskDto);
        }
    }
}