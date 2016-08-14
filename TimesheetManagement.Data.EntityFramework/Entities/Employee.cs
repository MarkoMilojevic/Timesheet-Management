using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TimesheetManagement.Data.EntityFramework.Entities
{
	public class Employee
	{
		public int EmployeeId { get; set; }

		public string FirstName { get; set; }

		public string LastName { get; set; }

		[Index(IsUnique = true)]
		[DataType(DataType.EmailAddress)]
		public string Email { get; set; }
	}
}
