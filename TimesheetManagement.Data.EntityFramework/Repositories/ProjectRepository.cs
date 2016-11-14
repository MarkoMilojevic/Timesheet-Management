﻿using System;
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
        public override int Add(ProjectDTO projectDto)
        {
            Project project = EfDtoMapper.CreateProject(projectDto);
            project = context.Projects.Add(project);
            context.SaveChanges();

            return project.ProjectId;
        }

        public override bool Remove(ProjectDTO projectDto)
        {
            Project project = EfDtoMapper.CreateProject(projectDto);
            context.Projects.Remove(project);

            return context.SaveChanges() != 0;
        }

        public override ProjectDTO Find(params int[] keys)
        {
            Project project = context.Projects
                .Include(p => p.Client)
                .SingleOrDefault(p => p.ProjectId == keys[0]);

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