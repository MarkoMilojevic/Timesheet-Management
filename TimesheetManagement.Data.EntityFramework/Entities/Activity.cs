using System.ComponentModel.DataAnnotations.Schema;

namespace TimesheetManagement.Data.EntityFramework.Entities
{
	public class Activity
	{
		public int ActivityId { get; set; }

		public string Name { get; set; }

		public int ClientId { get; set; }

		[ForeignKey(nameof(Activity.ClientId))]
		public virtual Client Client { get; set; }

		public int ProjectId { get; set; }

		[ForeignKey(nameof(Activity.ProjectId))]
		public virtual Project Project { get; set; }
	}
}
