using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TimesheetManagement.Data.EntityFramework.Entities
{
    public class TaskActivity
    {
        [Key]
        [Column(Order = 0)]
        public int TaskId { get; set; }

        [Key]
        [Column(Order = 1)]
        public int ActivityId { get; set; }

        [ForeignKey(nameof(TaskId))]
        public Task Task { get; set; }

        [ForeignKey(nameof(ActivityId))]
        public Activity Activity { get; set; }
    }
}
