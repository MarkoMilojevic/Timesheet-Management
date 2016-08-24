using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TimesheetManagement.Data.EntityFramework.Entities
{
	public class Project
	{
		[Key]
		public int ProjectId { get; set; }

		[Required]
		[StringLength(50)]
		public string Name { get; set; }

		[Required]
		public DateTime StartDate { get; set; }

		[Required]
		public DateTime EndDate { get; set; }

        [Required]
		public string AccountId { get; set; }

		[ForeignKey(nameof(Project.AccountId))]
		public virtual Account Account { get; set; }

		public virtual ICollection<Task> Tasks { get; set; }
	}
}
