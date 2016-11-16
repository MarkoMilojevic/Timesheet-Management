using System;
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
        public override TaskDTO Add(TaskDTO taskDto)
        {
            Task task = EfDtoMapper.CreateTask(taskDto);

            task = context.Tasks.Add(task);
            context.SaveChanges();

            return EfDtoMapper.CreateTaskDto(task);
        }

        public override bool Remove(TaskDTO taskDto)
        {
            Task task = EfDtoMapper.CreateTask(taskDto);

            context.Tasks.Remove(task);

            return context.SaveChanges() != 0;
        }

        public override TaskDTO Find(params int[] keys)
        {
            int taskId = keys[0];

            Task task = context.Tasks
                .Include(t => t.Project.Client)
                .SingleOrDefault(t => t.TaskId == taskId);

            return EfDtoMapper.CreateTaskDto(task);
        }

        public override bool Update(TaskDTO taskDto)
        {
            Task existingTask = context.Tasks.FirstOrDefault(t => t.TaskId == taskDto.TaskId);
            if (existingTask == null)
            {
                return false;
            }

            context.Entry(existingTask).State = EntityState.Detached;

            Task updatedTask = EfDtoMapper.CreateTask(taskDto);
            context.Tasks.Attach(updatedTask);
            context.Entry(updatedTask).State = EntityState.Modified;

            return context.SaveChanges() != 0;
        }

        public override IEnumerable<TaskDTO> Find(Expression<Func<TaskDTO, bool>> predicate)
        {
            Expression<Func<Task, bool>> efPredicate = EfExpressionTransformer<TaskDTO, Task>.Tranform(predicate);

            return context.Tasks
                .Where(efPredicate)
                .Include(t => t.Project.Client)
                .Select(EfDtoMapper.CreateTaskDto);
        }

        public override IEnumerable<TaskDTO> FindAll()
        {
            return context.Tasks
                .Include(t => t.Project.Client)
                .Select(EfDtoMapper.CreateTaskDto);
        }
    }
}
