using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using TimesheetManagement.Data.EntityFramework.Entities;
using TimesheetManagement.Data.EntityFramework.Helpers;
using EmployeeDTO = TimesheetManagement.Data.Entities.Employee;

namespace TimesheetManagement.Data.EntityFramework.Repositories
{
    public class EmployeeRepository : EfRepository<EmployeeDTO, int>
    {
        public override int Add(EmployeeDTO employeeDto)
        {
            Employee employee = EfDtoMapper.CreateEmployee(employeeDto);

            employee = context.Employees.Add(employee);
            context.SaveChanges();

            return employee.EmployeeId;
        }

        public override bool Remove(EmployeeDTO employeeDto)
        {
            Employee employee = EfDtoMapper.CreateEmployee(employeeDto);

            context.Employees.Remove(employee);

            return context.SaveChanges() != 0;
        }

        public override EmployeeDTO Find(params int[] keys)
        {
            int employeeId = keys[0];

            Employee employee = context.Employees.Find(employeeId);

            return EfDtoMapper.CreateEmployeeDto(employee);
        }

        public override IEnumerable<EmployeeDTO> Find(Expression<Func<EmployeeDTO, bool>> predicate)
        {
            Expression<Func<Employee, bool>> efPredicate = EfExpressionTransformer<EmployeeDTO, Employee>.Tranform(predicate);

            return context.Employees
                .Where(efPredicate)
                .Select(EfDtoMapper.CreateEmployeeDto);
        }

        public override IEnumerable<EmployeeDTO> FindAll()
        {
            return context.Employees.Select(EfDtoMapper.CreateEmployeeDto);
        }
    }
}
