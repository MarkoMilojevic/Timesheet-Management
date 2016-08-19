using System.Collections.Generic;
using System.Linq;
using TimesheetManagement.Data.EntityFramework.Common;
using TimesheetManagement.Data.EntityFramework.Entities;
using TimesheetManagement.Data.Interfaces.Common;
using EmployeeDTO = TimesheetManagement.Data.Entities.Employee;


namespace TimesheetManagement.Data.EntityFramework.Repositories
{
    public class EmployeeEFRepository : IEmployeeRepository
	{
		private readonly TimesheetContext context;

		public EmployeeEFRepository()
		{
			this.context = new TimesheetContext();
		}

        public EmployeeDTO GetEmployee(int employeeId)
        {
            Employee employee = this.context.Employees.Find(employeeId);

            return EfDtoMapper.CreateEmployee(employee);
        }

        public EmployeeDTO GetEmployee(string email)
        {
            Employee employee = this.context.Employees.FirstOrDefault(e => e.Email == email);

            return EfDtoMapper.CreateEmployee(employee);
        }

        public ICollection<EmployeeDTO> GetEmployees()
        {
            List<Employee> employees = this.context.Employees.ToList();

            return employees.Select(EfDtoMapper.CreateEmployee).ToList();
        }        
    }
}
