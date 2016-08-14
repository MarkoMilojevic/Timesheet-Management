using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TimesheetManagement.Data.EntityFramework.Entities
{
    public class Activity
    {
        public int ActivityId { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        public string ClientId { get; set; }

        [ForeignKey(nameof(ClientId))]
        public virtual Client Client{ get; set; }

        public int ProjectId { get; set; }

        [ForeignKey(nameof(ProjectId))]
        public virtual Project Project { get; set; }
    }
}
