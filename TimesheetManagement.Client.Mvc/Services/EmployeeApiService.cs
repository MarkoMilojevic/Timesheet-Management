using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Marvin.JsonPatch;
using TimesheetManagement.Client.Mvc.Common.Entities;
using TimesheetManagement.Client.Mvc.Common.Services;

namespace TimesheetManagement.Client.Mvc.Services
{
    public static class EmployeeApiService
    {
        private const string ControllerActionUri = "api/employees/";

        public static async Task<Employee> GetAsync(int employeeId)
        {
            return await ApiService.GetAsync<Employee>(ControllerActionUri + employeeId);
        }

        public static async Task<IEnumerable<Employee>> GetAsync()
        {
            return await ApiService.GetAsync<IEnumerable<Employee>>(ControllerActionUri);
        }

        public static async Task<HttpResponseMessage> PatchAsync(int employeeId, Employee employee)
        {
            JsonPatchDocument<Employee> patchDoc = new JsonPatchDocument<Employee>();

            patchDoc.Replace(e => e.FirstName, employee.FirstName);
            patchDoc.Replace(e => e.LastName, employee.LastName);
            patchDoc.Replace(e => e.Email, employee.Email);

            return await ApiService.PatchAsync(ControllerActionUri + employeeId, patchDoc);
        }

        public static async Task<HttpResponseMessage> PutAsync(Employee employee)
        {
            return await ApiService.PutAsync(ControllerActionUri, employee);
        }

        public static async Task<HttpResponseMessage> PostAsync(Employee employee)
        {
            return await ApiService.PostAsync(ControllerActionUri, employee);
        }

        public static async Task<HttpResponseMessage> DeleteAsync(int employeeId)
        {
            return await ApiService.DeleteAsync(ControllerActionUri + employeeId);
        }
    }
}
