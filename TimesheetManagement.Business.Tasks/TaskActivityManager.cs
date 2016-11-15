using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using TimesheetManagement.Business.Interfaces;
using TimesheetManagement.Business.Tasks.Entities;
using TimesheetManagement.Business.Tasks.Helpers;
using TimesheetManagement.Data.Interfaces;
using TaskActivityDTO = TimesheetManagement.Data.Tasks.Entities.TaskActivity;

namespace TimesheetManagement.Business.Tasks.Managers
{
    public class TaskActivityManager : IManager<TaskActivity, int>
    {
        private readonly IRepository<TaskActivityDTO, int> taskActivityRepository;

        public TaskActivityManager(IRepository<TaskActivityDTO, int> taskActivityRepository)
        {
            this.taskActivityRepository = taskActivityRepository;
        }

        public int Add(TaskActivity taskActivity)
        {
            TaskActivityDTO taskActivityDto = TasksBoMapper.CreateTaskActivityDto(taskActivity);

            return taskActivityRepository.Add(taskActivityDto);
        }

        public bool Remove(TaskActivity taskActivity)
        {
            TaskActivityDTO taskActivityDto = TasksBoMapper.CreateTaskActivityDto(taskActivity);

            return taskActivityRepository.Remove(taskActivityDto);
        }

        public TaskActivity Find(params int[] keys)
        {
            TaskActivityDTO taskActivityDto = taskActivityRepository.Find(keys);

            return TasksBoMapper.CreateTaskActivity(taskActivityDto);
        }

        public IEnumerable<TaskActivity> Find(Expression<Func<TaskActivity, bool>> predicate)
        {
            Expression<Func<TaskActivityDTO, bool>> dataPredicate = TasksExpressionTransformer<TaskActivity, TaskActivityDTO>.Tranform(predicate);

            return taskActivityRepository.Find(dataPredicate).Select(TasksBoMapper.CreateTaskActivity);
        }

        public IEnumerable<TaskActivity> FindAll()
        {
            return taskActivityRepository.FindAll().Select(TasksBoMapper.CreateTaskActivity);
        }
    }
}