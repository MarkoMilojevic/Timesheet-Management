using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TimesheetManagement.Data.EntityFramework.Entities
{
    public class EmployeeActivity
    {
        [Key]
        [Column(Order = 0)]
        public int EmployeeId { get; set; }

        [Key]
        [Column(Order = 1)]
        public int ActivityId { get; set; }

        [ForeignKey(nameof(ActivityId))]
        public virtual Activity Activity { get; set; }

        [ForeignKey(nameof(EmployeeId))]
        public virtual Employee Employee { get; set; }
    }
}