﻿using System;

namespace TimesheetManagement.Business.Tasks.Entities
{
    public class Project
    {
        public int ProjectId { get; set; }

        public string Name { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public Client Client { get; set; }
    }
}
