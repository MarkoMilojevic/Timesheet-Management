using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimesheetManagement.Data.EntityFramework.Entities
{
    public class EmployeeActivity
    {
        public int EmployeeId { get; set; }

        public int ActivityId { get; set; }

        public string Description { get; set; }

        [ForeignKey("ActivityId")]
        public virtual Activity Activity { get; set; }

        [ForeignKey("EmployeeId")]
        public virtual Employee Employee { get; set; }

    }
}
