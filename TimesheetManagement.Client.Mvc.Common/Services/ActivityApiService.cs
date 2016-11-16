using System.Collections.Generic;
using System.Threading.Tasks;
using TimesheetManagement.Client.Mvc.Common.Entities;

namespace TimesheetManagement.Client.Mvc.Common.Services
{
    public static class ActivityApiService
    {
        public static async Task<Activity> GetAsync(int activityId)
        {
            return await ApiService.Get<Activity>($"api/activities/{activityId}");
        }

        public static async Task<IEnumerable<Activity>> GetAsync()
        {
            return await ApiService.Get<IEnumerable<Activity>>("api/activities");
        }

        public static async Task<IEnumerable<Activity>> GetByEmployeeAsync(int employeeId)
        {
            return await ApiService.Get<IEnumerable<Activity>>($"api/employees/{employeeId}/activities");
        }
    }
}
