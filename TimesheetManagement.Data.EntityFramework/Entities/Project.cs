﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TimesheetManagement.Data.EntityFramework.Entities
{
	public class Project
	{
		public int ProjectId { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

		public DateTime StartDate { get; set; }

		public DateTime DueDate { get; set; }

		public string TaxpayerIdentificationNumber { get; set; }

		[ForeignKey(nameof(Project.TaxpayerIdentificationNumber))]
		public virtual Account Account { get; set; }

		public virtual ICollection<Activity> Activities { get; set; }
	}
}
