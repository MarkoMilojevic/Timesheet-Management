using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using TimesheetManagement.Business.Interfaces;
using TimesheetManagement.Business.Tasks.Entities;
using TimesheetManagement.Business.Tasks.Helpers;
using TimesheetManagement.Data.Interfaces;
using ProjectDTO = TimesheetManagement.Data.Tasks.Entities.Project;

namespace TimesheetManagement.Business.Tasks.Managers
{
    public class ProjectManager : IManager<Project, int>
    {
        private readonly IRepository<ProjectDTO, int> projectRepository;

        public ProjectManager(IRepository<ProjectDTO, int> projectRepository)
        {
            this.projectRepository = projectRepository;
        }

        public Project Add(Project project)
        {
            ProjectDTO projectDto = TasksBoMapper.CreateProjectDto(project);

            projectDto = projectRepository.Add(projectDto);

            return TasksBoMapper.CreateProject(projectDto);
        }

        public bool Remove(Project project)
        {
            ProjectDTO projectDto = TasksBoMapper.CreateProjectDto(project);

            return projectRepository.Remove(projectDto);
        }

        public bool Update(Project project)
        {
            ProjectDTO projectDto = TasksBoMapper.CreateProjectDto(project);

            return projectRepository.Update(projectDto);
        }

        public Project Find(params int[] keys)
        {
            ProjectDTO projectDto = projectRepository.Find(keys);

            return TasksBoMapper.CreateProject(projectDto);
        }

        public IEnumerable<Project> Find(Expression<Func<Project, bool>> predicate)
        {
            Expression<Func<ProjectDTO, bool>> dataPredicate = TasksExpressionTransformer<Project, ProjectDTO>.Tranform(predicate);

            return projectRepository.Find(dataPredicate).Select(TasksBoMapper.CreateProject);
        }

        public IEnumerable<Project> FindAll()
        {
            return projectRepository.FindAll().Select(TasksBoMapper.CreateProject);
        }
    }
}