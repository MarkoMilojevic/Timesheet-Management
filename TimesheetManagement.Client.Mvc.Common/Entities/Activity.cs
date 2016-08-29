using System;
using System.ComponentModel.DataAnnotations;

namespace TimesheetManagement.Client.Mvc.Common.Entities
{
	public class Activity
	{
		public int ActivityId { get; set; }
        
        [Display(Name = "Start Date")]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [Display(Name = "End Date")]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        [Display(Name = "Hours")]
        [Range(0, int.MaxValue)]
        public int DurationInHours { get; set; }

		public string Description { get; set; }

        [Display(Name = "Is Approved")]
        public bool IsApproved { get; set; }

		public int EmployeeId { get; set; }
	}
}
