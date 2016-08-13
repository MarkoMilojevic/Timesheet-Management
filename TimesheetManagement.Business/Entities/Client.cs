using System.Collections.Generic;

namespace TimesheetManagement.Business.Entities
{
    public class Client
    {
        public string Name { get; set; }

        public string RegisterNumber { get; set; }

        public string TaxpayerIdentificationNumber { get; set; }

        public ICollection<Project> Projects { get; set; }
    }
}