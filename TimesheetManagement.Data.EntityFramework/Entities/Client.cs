using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TimesheetManagement.Data.EntityFramework.Entities
{
	public class Client
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		[Display(Name = "TIN")]
		[MinLength(9, ErrorMessage = "TIN must have 9 characters")]
		[MaxLength(9, ErrorMessage = "TIN must have 9 characters")]
		public string TaxpayerIdentificationNumber { get; set; }

		[Required]
		[StringLength(50)]
		public string Name { get; set; }

		[Display(Name = "RN")]
		[MinLength(8, ErrorMessage = "RN must have 8 characters")]
		[MaxLength(8, ErrorMessage = "RN must have 8 characters")]
		public string RegisterNumber { get; set; }

		public virtual ICollection<Project> Projects { get; set; }
	}
}
