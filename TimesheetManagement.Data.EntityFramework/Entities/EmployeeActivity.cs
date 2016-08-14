using System.ComponentModel.DataAnnotations.Schema;

namespace TimesheetManagement.Data.EntityFramework.Entities
{
	public class EmployeeActivity
	{
		public int EmployeeId { get; set; }

		public int ActivityId { get; set; }

		[ForeignKey(nameof(EmployeeActivity.ActivityId))]
		public virtual Activity Activity { get; set; }

		[ForeignKey(nameof(EmployeeActivity.EmployeeId))]
		public virtual Employee Employee { get; set; }
	}
}
