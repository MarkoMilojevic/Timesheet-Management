using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Marvin.JsonPatch;
using TimesheetManagement.Client.Mvc.Common.Entities;
using TimesheetManagement.Client.Mvc.Common.Services;

namespace TimesheetManagement.Client.Mvc.Services
{
    public static class ActivityApiService
    {
        private const string ControllerActionUri = "api/activities/";

        public static async Task<Activity> GetAsync(int activityId)
        {
            return await ApiService.GetAsync<Activity>(ControllerActionUri + activityId);
        }

        public static async Task<IEnumerable<Activity>> GetAsync()
        {
            return await ApiService.GetAsync<IEnumerable<Activity>>(ControllerActionUri);
        }

        public static async Task<IEnumerable<Activity>> GetByEmployeeAsync(int employeeId)
        {
            return await ApiService.GetAsync<IEnumerable<Activity>>($"api/employees/{employeeId}/activities");
        }

        public static async Task<HttpResponseMessage> PatchAsync(int activityId, Activity activity)
        {
            JsonPatchDocument<Activity> patchDoc = new JsonPatchDocument<Activity>();

            patchDoc.Replace(a => a.StartDate, activity.StartDate);
            patchDoc.Replace(a => a.EndDate, activity.EndDate);
            patchDoc.Replace(a => a.DurationInHours, activity.DurationInHours);
            patchDoc.Replace(a => a.Description, activity.Description);
            patchDoc.Replace(a => a.IsApproved, activity.IsApproved);

            return await ApiService.PatchAsync(ControllerActionUri + activityId, patchDoc);
        }

        public static async Task<HttpResponseMessage> PutAsync(Activity activity)
        {
            return await ApiService.PutAsync(ControllerActionUri, activity);
        }

        public static async Task<HttpResponseMessage> PostAsync(Activity activity)
        {
            return await ApiService.PostAsync(ControllerActionUri, activity);
        }

        public static async Task<HttpResponseMessage> DeleteAsync(int activityId)
        {
            return await ApiService.DeleteAsync(ControllerActionUri + activityId);
        }
    }
}
