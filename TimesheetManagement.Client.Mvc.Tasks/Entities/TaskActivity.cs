using TimesheetManagement.Client.Mvc.Common.Entities;

namespace TimesheetManagement.Client.Mvc.Tasks.Entities
{
    public class TaskActivity
    {
        public Task Task { get; set; }

        public Activity Activity { get; set; }
    }
}
