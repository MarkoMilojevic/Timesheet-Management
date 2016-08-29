using TimesheetManagement.Client.Mvc.Common.Entities;

namespace TimesheetManagement.Client.Mvc.Tasks.Entities
{
    public class TaskActivity
    {
        public int TaskId { get; set; }

        public Activity Activity { get; set; }
    }
}
