using EmpMgmt.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmpMgmt.DataAccess
{
    public class EmployeeManagementContext : DbContext
    {
        public EmployeeManagementContext(DbContextOptions<EmployeeManagementContext> options) : base(options)
        { }

        public DbSet<Employee> Employee { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(EmployeeManagementContext).Assembly);
        }
    }
}
