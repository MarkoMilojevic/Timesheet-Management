using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using TimesheetManagement.Business.Interfaces;
using TimesheetManagement.Business.Tasks.Entities;
using TimesheetManagement.Business.Tasks.Helpers;
using TimesheetManagement.Data.Interfaces;
using TaskDTO = TimesheetManagement.Data.Tasks.Entities.Task;

namespace TimesheetManagement.Business.Tasks.Managers
{
    public class TaskManager : IManager<Task, int>
    {
        private readonly IRepository<TaskDTO, int> taskRepository;

        public TaskManager(IRepository<TaskDTO, int> taskRepository)
        {
            this.taskRepository = taskRepository;
        }

        public int Add(Task task)
        {
            TaskDTO taskDto = TasksBoMapper.CreateTaskDto(task);

            return taskRepository.Add(taskDto);
        }

        public bool Remove(Task task)
        {
            TaskDTO taskDto = TasksBoMapper.CreateTaskDto(task);

            return taskRepository.Remove(taskDto);
        }

        public Task Find(params int[] keys)
        {
            TaskDTO taskDto = taskRepository.Find(keys);

            return TasksBoMapper.CreateTask(taskDto);
        }

        public IEnumerable<Task> Find(Expression<Func<Task, bool>> predicate)
        {
            Expression<Func<TaskDTO, bool>> dataPredicate = TasksExpressionTransformer<Task, TaskDTO>.Tranform(predicate);

            return taskRepository.Find(dataPredicate).Select(TasksBoMapper.CreateTask);
        }

        public IEnumerable<Task> FindAll()
        {
            return taskRepository.FindAll().Select(TasksBoMapper.CreateTask);
        }
    }
}