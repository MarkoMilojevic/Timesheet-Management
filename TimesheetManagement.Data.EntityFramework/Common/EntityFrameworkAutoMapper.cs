using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimesheetManagement.Data.EntityFramework.Entities;
using ActivityDTO = TimesheetManagement.Data.DataContracts.Activity;
using ClientDTO = TimesheetManagement.Data.DataContracts.Client;
using EmployeeDTO = TimesheetManagement.Data.DataContracts.Employee;
using EmployeeActivityDTO = TimesheetManagement.Data.DataContracts.EmployeeActivity;
using ProjectDTO = TimesheetManagement.Data.DataContracts.Project;

namespace TimesheetManagement.Data.EntityFramework.Common
{
    public static class EntityFrameworkAutoMapper
    {
        static EntityFrameworkAutoMapper()
        {          
        }

        public static ClientDTO CreateClient(Client client)
        {
            return null;
        }

        public static ProjectDTO CreateProject(Project project)
        {
            return null;
        }

        public static ActivityDTO CreateActivity(Activity activity)
        {
            return null;
        }

        public static EmployeeDTO CreateEmployee(Employee employee)
        {
            return null;
        }

        public static EmployeeActivityDTO CreateEmployeeActivity(EmployeeActivity employeeActivity)
        {
            return null;
        }

    }
}
