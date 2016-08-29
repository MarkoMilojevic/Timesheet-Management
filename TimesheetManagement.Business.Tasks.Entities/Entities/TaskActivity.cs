using TimesheetManagement.Business.Entities;

namespace TimesheetManagement.Business.Tasks.Entities
{
    public class TaskActivity
    {
        public int TaskId { get; set; }

        public Activity Activity { get; set; }
    }
}
