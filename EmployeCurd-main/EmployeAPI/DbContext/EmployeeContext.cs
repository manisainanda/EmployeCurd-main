using EmployeAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeAPI.context
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext(DbContextOptions<EmployeeContext> options) : base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }
    }
        
    
}
