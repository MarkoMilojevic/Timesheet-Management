using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimesheetManagement.Data.DataContracts;

namespace TimesheetManagement.Data.Repositories
{
    public interface IRepository
    {
        Client GetClient(string tin);

        ICollection<Client> GetClients();

        Project GetProject(int id);

        ICollection<Project> GetProjects();

        Activity GetActivity(int id);

        ICollection<Activity> GetActivities(int projectId);

        Employee GetEmployee(int id);

        Employee GetEmployee(string email);

        ICollection<Employee> GetEmployees();

        ICollection<EmployeeActivity> GetEmployeeActivities(int employeeId);
    }
}
