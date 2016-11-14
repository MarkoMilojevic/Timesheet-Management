﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using TimesheetManagement.Business.Entities;
using TimesheetManagement.Business.Tasks.Entities;
using ActivityDTO = TimesheetManagement.Data.Entities.Activity;
using EmployeeDTO = TimesheetManagement.Data.Entities.Employee;
using ClientDTO = TimesheetManagement.Data.Tasks.Entities.Client;
using ProjectDTO = TimesheetManagement.Data.Tasks.Entities.Project;
using TaskDTO = TimesheetManagement.Data.Tasks.Entities.Task;
using TaskActivityDTO = TimesheetManagement.Data.Tasks.Entities.TaskActivity;

namespace TimesheetManagement.Business.Tasks.Helpers
{
    public static class ExpressionTransformer<TFrom, TTo>
    {
        public static Expression<Func<TTo, bool>> Tranform(Expression<Func<TFrom, bool>> expression)
        {
            ParameterExpression parameter = Expression.Parameter(typeof(TTo));
            Expression body = new Visitor(parameter).Visit(expression.Body);

            return Expression.Lambda<Func<TTo, bool>>(body, parameter);
        }

        public class Visitor : ExpressionVisitor
        {
            private readonly Dictionary<Type, Type> mapper;
            private readonly ParameterExpression parameter;

            public Visitor(ParameterExpression parameter)
            {
                this.parameter = parameter;
                mapper = new Dictionary<Type, Type>
                {
                    {typeof(Employee), typeof(EmployeeDTO)},
                    {typeof(Activity), typeof(ActivityDTO)},
                    {typeof(Client), typeof(ClientDTO)},
                    {typeof(Project), typeof(ProjectDTO)},
                    {typeof(Task), typeof(TaskDTO)},
                    {typeof(TaskActivity), typeof(TaskActivityDTO)}
                };
            }

            protected override Expression VisitParameter(ParameterExpression node)
            {
                return parameter;
            }

            protected override Expression VisitMember(MemberExpression node)
            {
                if (node.Member.MemberType != MemberTypes.Property)
                {
                    return base.VisitMember(node);
                }

                string memberName = node.Member.Name;
                if (node.Member.ReflectedType == null)
                {
                    return Expression.Empty();
                }

                PropertyInfo member = mapper[node.Member.ReflectedType].GetProperty(memberName);
                if (member == null)
                {
                    return Expression.Empty();
                }

                return Expression.Property(Visit(node.Expression), member);
            }
        }
    }
}