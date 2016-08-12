using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TimesheetManagement.Data.EntityFramework.Entities
{
    public class Project
    {
        public int ProjectId { get; set; }

        public string Name { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime DueDate { get; set; }

        public string TaxpayerIdentificationNumber { get; set; }

        [ForeignKey(nameof(TaxpayerIdentificationNumber))]
        public virtual Client Client { get; set; }

        public virtual ICollection<Activity> Activities { get; set; }
    }
}