using EmployeAPI.Models;
using System.Collections.Generic;

namespace EmployeAPI.EmployeeServices
{
    public interface IEmployeeService
    {
        Employee AddEmployee(Employee employee);

        List<Employee> GetEmployees();

        void UpdateEmployee(Employee employee, int id);

        void DeleteEmployee(int Id);

        Employee GetEmployee(int Id);
    }
}
