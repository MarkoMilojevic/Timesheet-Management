using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TimesheetManagement.Data.EntityFramework.Entities
{
    public class Activity
    {
        public int ActivityId { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        public string AccountId { get; set; }

		[ForeignKey(nameof(Activity.AccountId))]
		public virtual Account Account { get; set; }

		public int ProjectId { get; set; }

		[ForeignKey(nameof(Activity.ProjectId))]
		public virtual Project Project { get; set; }
	}
}
