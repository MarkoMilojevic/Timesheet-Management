using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using TimesheetManagement.Data.EntityFramework.Entities;
using TimesheetManagement.Data.EntityFramework.Helpers;
using ProjectDTO = TimesheetManagement.Data.Tasks.Entities.Project;

namespace TimesheetManagement.Data.EntityFramework.Repositories
{
    public class ProjectRepository : EfRepository<ProjectDTO, int>
    {
        public override ProjectDTO Add(ProjectDTO projectDto)
        {
            Project project = EfDtoMapper.CreateProject(projectDto);

            project = context.Projects.Add(project);
            context.SaveChanges();

            return EfDtoMapper.CreateProjectDto(project);
        }

        public override bool Remove(ProjectDTO projectDto)
        {
            Project project = EfDtoMapper.CreateProject(projectDto);

            context.Projects.Remove(project);

            return context.SaveChanges() != 0;
        }

        public override bool Update(ProjectDTO projectDto)
        {
            Project existingProject = context.Projects.FirstOrDefault(p => p.ProjectId == projectDto.ProjectId);
            if (existingProject == null)
            {
                return false;
            }

            context.Entry(existingProject).State = EntityState.Detached;

            Project updatedProject = EfDtoMapper.CreateProject(projectDto);
            context.Projects.Attach(updatedProject);
            context.Entry(updatedProject).State = EntityState.Modified;

            return context.SaveChanges() != 0;
        }

        public override ProjectDTO Find(params int[] keys)
        {
            int projectId = keys[0];

            Project project = context.Projects
                .Include(p => p.Client)
                .SingleOrDefault(p => p.ProjectId == projectId);

            return EfDtoMapper.CreateProjectDto(project);
        }

        public override IEnumerable<ProjectDTO> Find(Expression<Func<ProjectDTO, bool>> predicate)
        {
            Expression<Func<Project, bool>> efPredicate = EfExpressionTransformer<ProjectDTO, Project>.Tranform(predicate);

            return context.Projects.Where(efPredicate)
                .Include(p => p.Client)
                .Select(EfDtoMapper.CreateProjectDto);
        }

        public override IEnumerable<ProjectDTO> FindAll()
        {
            return context.Projects
                .Include(p => p.Client)
                .Select(EfDtoMapper.CreateProjectDto);
        }
    }
}
