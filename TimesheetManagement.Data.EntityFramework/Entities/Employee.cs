using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TimesheetManagement.Data.EntityFramework.Entities
{
	public class Employee
	{
		public int EmployeeId { get; set; }

        [StringLength(30)]
        public string FirstName { get; set; }

        [StringLength(30)]
        public string LastName { get; set; }

        [StringLength(50)]
        [Index(IsUnique = true)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}