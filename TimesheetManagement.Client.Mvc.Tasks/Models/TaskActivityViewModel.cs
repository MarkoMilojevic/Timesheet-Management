using System.ComponentModel.DataAnnotations;
using TimesheetManagement.Client.Mvc.Common.Entities;

namespace TimesheetManagement.Client.Mvc.Tasks.Models
{
    public class TaskActivityViewModel
    {
        [Display(Name = "Client")]
        public string AccountName { get; set; }

        public string AccountId { get; set; }

        [Display(Name = "Project")]
        public string ProjectName { get; set; }

        public int ProjectId { get; set; }

        [Display(Name = "Task")]
        public string TaskName { get; set; }

        public int TaskId { get; set; }

        public Activity Activity { get; set; }
    }
}
