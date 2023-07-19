using Microsoft.EntityFrameworkCore;

namespace CodeFirstAvinash.Models
{
    public class DbContextEmployee:DbContext
    {
        public DbContextEmployee(DbContextOptions<DbContextEmployee> options):base(options)
        {
            
        }
        public DbSet<Employee> Employees { get; set; }
    }
}
