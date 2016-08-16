using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TimesheetManagement.Data.EntityFramework.Entities
{
	public class Employee
	{
        [Key]
		public int EmployeeId { get; set; }

		[Required]
		[StringLength(30)]
		public string FirstName { get; set; }

		[Required]
		[StringLength(50)]
		public string LastName { get; set; }

		[Index(IsUnique = true)]
		[Required]
		[StringLength(80)]
		[DataType(DataType.EmailAddress)]
		public string Email { get; set; }

	    public virtual ICollection<Activity> Activities { get; set; }
	}
}
