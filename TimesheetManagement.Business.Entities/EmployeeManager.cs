using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using TimesheetManagement.Business.Entities;
using TimesheetManagement.Business.Helpers;
using TimesheetManagement.Business.Interfaces;
using TimesheetManagement.Data.Interfaces;
using EmployeeDTO = TimesheetManagement.Data.Entities.Employee;

namespace TimesheetManagement.Business.Managers
{
    public class EmployeeManager : IManager<Employee, int>
    {
        private readonly IRepository<EmployeeDTO, int> employeeRepository;

        public EmployeeManager(IRepository<EmployeeDTO, int> employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }

        public Employee Add(Employee employee)
        {
            EmployeeDTO employeeDto = CoreBoMapper.CreateEmployeeDto(employee);

            employeeDto = employeeRepository.Add(employeeDto);

            return CoreBoMapper.CreateEmployee(employeeDto);
        }

        public bool Remove(Employee employee)
        {
            EmployeeDTO employeeDto = CoreBoMapper.CreateEmployeeDto(employee);

            return employeeRepository.Remove(employeeDto);
        }

        public bool Update(Employee employee)
        {
            EmployeeDTO employeeDto = CoreBoMapper.CreateEmployeeDto(employee);

            return employeeRepository.Update(employeeDto);
        }

        public Employee Find(params int[] keys)
        {
            EmployeeDTO employeeDto = employeeRepository.Find(keys);

            return CoreBoMapper.CreateEmployee(employeeDto);
        }

        public IEnumerable<Employee> Find(Expression<Func<Employee, bool>> predicate)
        {
            Expression<Func<EmployeeDTO, bool>> dataPredicate = CoreExpressionTransformer<Employee, EmployeeDTO>.Tranform(predicate);

            return employeeRepository.Find(dataPredicate).Select(CoreBoMapper.CreateEmployee);
        }

        public IEnumerable<Employee> FindAll()
        {
            return employeeRepository.FindAll().Select(CoreBoMapper.CreateEmployee);
        }
    }
}