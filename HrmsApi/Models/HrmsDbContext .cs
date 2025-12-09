using Microsoft.EntityFrameworkCore;

namespace HrmsApi.Models
{
    public class HrmsDbContext : DbContext
    {
        public HrmsDbContext(DbContextOptions<HrmsDbContext> options)
            : base(options)
        { }

        public DbSet<Employee> Employees { get; set; }
    }
}
