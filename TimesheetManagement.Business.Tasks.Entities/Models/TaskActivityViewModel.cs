using TimesheetManagement.Business.Entities;
using TimesheetManagement.Business.Tasks.Entities;

namespace TimesheetManagement.Business.Tasks.Models
{
    public class TaskActivityViewModel
    {
        public string AccountId { get; set; }

        public string AccountName { get; set; }

        public int ProjectId { get; set; }

        public string ProjectName { get; set; }

        public Task Task { get; set; }

        public Activity Activity { get; set; }
    }
}