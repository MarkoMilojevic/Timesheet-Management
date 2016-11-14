using TimesheetManagement.Business.Entities;

namespace TimesheetManagement.Business.Tasks.Entities
{
    public class TaskActivity
    {
        public Task Task { get; set; }

        public Activity Activity { get; set; }
    }
}