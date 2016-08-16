using System.Collections.Generic;
using System.Linq;
using TimesheetManagement.Business.Common;
using TimesheetManagement.Business.Entities;
using TimesheetManagement.Data.Repositories;
using EmployeeDTO = TimesheetManagement.Data.Entities.Employee;
using ActivityDTO = TimesheetManagement.Data.Entities.Activity;

namespace TimesheetManagement.Business.Managers
{
    public class TasksManager
    {
        private readonly IEmployeeRepository employeeRepository;
        private readonly IActivityRepository activityRepository;

        public TasksManager(IEmployeeRepository employeeRepository, IActivityRepository activityRepository)
        {
            this.employeeRepository = employeeRepository;
            this.activityRepository = activityRepository;
        }

        public Activity GetActivity(int activityId)
        {
            ActivityDTO activity = this.activityRepository.GetActivity(activityId);

            return CommonAutoMapper.CreateActivity(activity);
        }

        public ICollection<Activity> GetActivities(int employeeId)
        {
            ICollection<ActivityDTO> activities = this.activityRepository.GetActivities(employeeId).ToList();

            return activities.Select(CommonAutoMapper.CreateActivity).ToList();
        }

        public Employee GetEmployee(int employeeId)
        {
            EmployeeDTO employee = this.employeeRepository.GetEmployee(employeeId);

            return CommonAutoMapper.CreateEmployee(employee);
        }

        public Employee GetEmployee(string email)
        {
            EmployeeDTO employee = this.employeeRepository.GetEmployee(email);

            return CommonAutoMapper.CreateEmployee(employee);
        }

        public ICollection<Employee> GetEmployees()
        {
            ICollection<EmployeeDTO> employees = this.employeeRepository.GetEmployees().ToList();

            return employees.Select(CommonAutoMapper.CreateEmployee).ToList();
        }
    }
}
