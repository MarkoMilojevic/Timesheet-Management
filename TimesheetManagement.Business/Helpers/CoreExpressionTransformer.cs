using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using TimesheetManagement.Business.Entities;
using ActivityDTO = TimesheetManagement.Data.Entities.Activity;
using EmployeeDTO = TimesheetManagement.Data.Entities.Employee;

namespace TimesheetManagement.Business.Helpers
{
    public static class CoreExpressionTransformer<TFrom, TTo>
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
                    {typeof(Activity), typeof(ActivityDTO)}
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

                Expression inner = Visit(node.Expression);
                string memberName = node.Member.Name;
                PropertyInfo member = mapper[node.Member.ReflectedType].GetProperty(memberName);

                return Expression.Property(inner, member);
            }
        }
    }
}
