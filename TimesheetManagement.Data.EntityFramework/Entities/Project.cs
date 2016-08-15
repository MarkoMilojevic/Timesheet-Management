using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TimesheetManagement.Data.EntityFramework.Entities
{
	public class Project
	{
		public int ProjectId { get; set; }

		[Required]
		[StringLength(50)]
		public string Name { get; set; }

		[Required]
		public DateTime StartDate { get; set; }

		[Required]
		public DateTime EndDate { get; set; }

		public string TaxpayerIdentificationNumber { get; set; }

		[ForeignKey(nameof(Project.TaxpayerIdentificationNumber))]
		public virtual Account Account { get; set; }

		public virtual ICollection<Task> Tasks { get; set; }
	}
}
