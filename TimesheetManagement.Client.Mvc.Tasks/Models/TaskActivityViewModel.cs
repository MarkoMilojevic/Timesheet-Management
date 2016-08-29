using System.ComponentModel.DataAnnotations;
using TimesheetManagement.Client.Mvc.Common.Entities;
using TimesheetManagement.Client.Mvc.Tasks.Entities;

namespace TimesheetManagement.Client.Mvc.Tasks.Models
{
    public class TaskActivityViewModel
    {
        [Display(Name = "Client")]
        public string AccountId { get; set; }

        public string AccountName { get; set; }

        [Display(Name = "Project")]
        public int ProjectId { get; set; }

        public string ProjectName { get; set; }

        [Display(Name = "Task")]
        public int TaskId { get; set; }

        public string TaskName { get; set; }

        public Activity Activity { get; set; }
    }
}
