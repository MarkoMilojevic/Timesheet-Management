using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TimesheetManagement.Data.EntityFramework.Entities
{
	public class TaskActivity
	{
		[Key]
		public int TaskId { get; set; }

		[ForeignKey(nameof(TaskActivity.TaskId))]
		public virtual Task Task { get; set; }

		public virtual ICollection<Activity> Activities { get; set; }
	}
}
