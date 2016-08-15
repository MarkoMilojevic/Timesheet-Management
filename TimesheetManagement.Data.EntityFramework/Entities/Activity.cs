﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TimesheetManagement.Data.EntityFramework.Entities
{
	public class Activity
	{
		public int ActivityId { get; set; }

		[Required]
		[Display(Name = "Start Date")]
		public DateTime StartDate { get; set; }

		[Required]
		[Display(Name = "End Date")]
		public DateTime EndDate { get; set; }

		[Required]
		[Display(Name = "Duration (hours)")]
		public int DurationInHours { get; set; }

		[StringLength(500)]
		public string Description { get; set; }

		[Display(Name = "Is Approved")]
		public bool IsApproved { get; set; }

		public int EmployeeId { get; set; }

		[ForeignKey(nameof(Activity.EmployeeId))]
		public Employee Employee { get; set; }
	}
}
