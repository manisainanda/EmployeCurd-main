using EmployeAPI.EmployeeServices;
using EmployeAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace EmployeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public IEnumerable<Employee> GetEmployees()
        {
            return _employeeService.GetEmployees();
        }

        [HttpPost]
        public IActionResult AddEmployee(Employee employee)
        {
            _employeeService.AddEmployee(employee);
            return Ok();
        }

        [HttpPut("{id}")]
         
        public IActionResult UpdateEmployee([FromBody]Employee employee, int id)
        {
            var existingEmployee = _employeeService.GetEmployee(id);
            if(existingEmployee != null)
            {
                _employeeService.UpdateEmployee(employee, id);
                return Ok();
            }
            return NotFound($"The Employee was not found with Id: {id}");

        }

        [HttpDelete("{id}")]
         
         
        public IActionResult DeleteEmployee(int id)
        {
            var existingEmployee = _employeeService.GetEmployee(id);
            if (existingEmployee != null)
            {
                _employeeService.DeleteEmployee(existingEmployee.Id);
                return Ok();
            }
            return NotFound($"Employee Not Found with ID : {id}");
        }

        [HttpGet("{id}")]
        public Employee GetEmployee(int id)
        {
            return _employeeService.GetEmployee(id);
        }
    }
}
