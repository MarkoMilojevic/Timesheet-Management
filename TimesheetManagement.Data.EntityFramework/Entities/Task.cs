using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TimesheetManagement.Data.EntityFramework.Entities
{
	public class Task
	{
		[Key]
		public int TaskId { get; set; }

		[Required]
		[StringLength(50)]
		public string Name { get; set; }

		public string AccountId { get; set; }

		public int ProjectId { get; set; }

		[ForeignKey(nameof(Task.AccountId))]
		public Account Account { get; set; }

		[ForeignKey(nameof(Task.ProjectId))]
		public Project Project { get; set; }
	}
}
