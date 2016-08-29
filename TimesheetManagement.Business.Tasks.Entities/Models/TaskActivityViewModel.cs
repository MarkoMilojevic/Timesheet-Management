using TimesheetManagement.Business.Entities;

namespace TimesheetManagement.Business.Tasks.Models
{
    public class TaskActivityViewModel
    {
        public string AccountId { get; set; }

        public string AccountName { get; set; }

        public int ProjectId { get; set; }

        public string ProjectName { get; set; }

        public int TaskId { get; set; }

        public string TaskName { get; set; }

        public Activity Activity { get; set; }
    }
}
