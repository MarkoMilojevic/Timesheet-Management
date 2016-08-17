using System;
using System.Collections.Generic;
using TimesheetManagement.Business.Entities.Entities;

namespace TimesheetManagement.Business.Interfaces.Common
{
    public interface ICommonManager
    {
        Activity GetActivity(int activityId);

        ICollection<Activity> GetActivities(int employeeId);

        Employee GetEmployee(int employeeId);

        Employee GetEmployee(string email);

        ICollection<Employee> GetEmployees();
    }
}
