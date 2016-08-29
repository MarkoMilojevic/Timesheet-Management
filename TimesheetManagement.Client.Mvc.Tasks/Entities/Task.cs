using System.ComponentModel.DataAnnotations;

namespace TimesheetManagement.Client.Mvc.Tasks.Entities
{
	public class Task
	{
        [Display(Name = "Task")]
        public int TaskId { get; set; }

        public string Name { get; set; }

		public int ProjectId { get; set; }
	}
}
