using System;
using System.Collections.Generic;

namespace TimesheetManagement.Business.Entities
{
    public class Project
    {
        public int ProjectId { get; set; }

        public string Name { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public Client Client { get; set; }

        public ICollection<Activity> Activities { get; set; }
    }
}