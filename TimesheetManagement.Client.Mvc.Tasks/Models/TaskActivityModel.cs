using TimesheetManagement.Client.Mvc.Common.Entities;

namespace TimesheetManagement.Client.Mvc.Tasks.Models
{
    public class TaskActivityModel
    {
        public string AccountName { get; set; }

        public string AccountId { get; set; }

        public string ProjectName { get; set; }

        public int ProjectId { get; set; }

        public string TaskName { get; set; }

        public int TaskId { get; set; }

        public Activity Activity { get; set; }

    }
}
