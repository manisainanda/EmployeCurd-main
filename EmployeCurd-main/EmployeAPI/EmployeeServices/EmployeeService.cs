using EmployeAPI.Models;
using System.Collections.Generic;
using System.Linq;
using EmployeAPI.context;

namespace EmployeAPI.EmployeeServices
{
    public class EmployeeService : IEmployeeService
    {
        public EmployeeContext _employeeDbContext;
        public EmployeeService(EmployeeContext employeeDbContext)
        {
            _employeeDbContext = employeeDbContext;
        }
        public Employee AddEmployee(Employee employee)
        {
            _employeeDbContext.Employees.Add(employee);
            _employeeDbContext.SaveChanges();
            return employee;
        }
        public List<Employee> GetEmployees()
        {
            return _employeeDbContext.Employees.ToList();
        }

        public void UpdateEmployee(Employee employee, int id)
        {
            var employeeToUpdate = _employeeDbContext.Employees.FirstOrDefault(x => x.Id == id);
            if (employeeToUpdate != null)
            {
                employeeToUpdate.FirstName = employee.FirstName;
                employeeToUpdate.LastName = employee.LastName;
                employeeToUpdate.Email = employee.Email;
                employeeToUpdate.City = employee.City;
                employeeToUpdate.Salary = employee.Salary;
                _employeeDbContext.Employees.Update(employeeToUpdate);
                _employeeDbContext.SaveChanges();
            }
            else
            {
                throw new System.Exception("Employee not found");
            }
        }

        public void DeleteEmployee(int Id)
        {
            var employee = _employeeDbContext.Employees.FirstOrDefault(x => x.Id == Id);
            if (employee != null)
            {
                _employeeDbContext.Remove(employee);
                _employeeDbContext.SaveChanges();
            }
            else
            {
                throw new System.Exception("Employee not found");
            }
        }

        public Employee GetEmployee(int Id)
        {
            return _employeeDbContext.Employees.FirstOrDefault(x => x.Id == Id);
        }
    }
}
