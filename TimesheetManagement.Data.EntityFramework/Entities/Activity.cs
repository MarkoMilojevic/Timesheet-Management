using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimesheetManagement.Data.EntityFramework.Entities
{
    public class Activity
    {
        public int ActivityId { get; set; }
        
        public string Name { get; set; }

        public int ProjectId { get; set; }

        public virtual Project Project { get; set; }
    }
}
