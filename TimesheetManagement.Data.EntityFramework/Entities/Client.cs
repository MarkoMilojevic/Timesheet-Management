using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimesheetManagement.Data.EntityFramework.Entities
{
    public class Client
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "TIN")]
        [MinLength(9, ErrorMessage = "TIN must have 9 characters"), MaxLength(9, ErrorMessage = "TIN must have 9 characters")]
        public string TaxpayerIdentificationNumber { get; set; }

        [StringLength(100)]
        [Required]
        public string Name { get; set; }

        public string RegisterNumber { get; set; }

        public virtual ICollection<Project> Projects { get; set; }
    }
}