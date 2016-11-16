using System.Collections.Generic;
using System.Threading.Tasks;
using TimesheetManagement.Client.Mvc.Common.Entities;

namespace TimesheetManagement.Client.Mvc.Common.Services
{
    public static class EmployeeApiService
    {
        public static async Task<Employee> GetAsync(int employeeId)
        {
            return await ApiService.Get<Employee>($"api/employees/{employeeId}");
        }

        public static async Task<IEnumerable<Employee>> GetAsync()
        {
            return await ApiService.Get<IEnumerable<Employee>>("api/employees");
        }
    }
}
