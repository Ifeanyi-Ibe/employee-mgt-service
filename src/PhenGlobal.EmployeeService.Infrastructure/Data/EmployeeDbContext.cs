using Microsoft.EntityFrameworkCore;
using PhenGlobal.EmployeeService.Application.Common.Interfaces;
using PhenGlobal.EmployeeService.Domain.Common;
using PhenGlobal.EmployeeService.Domain.Entities;

namespace PhenGlobal.EmployeeService.Infrastructure.Data
{
    public class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(EmployeeDbContext).Assembly);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach(var entry in ChangeTracker.Entries<BaseEntity>())
            {
                entry.Entity.LastModified = DateTime.Now;

                if(entry.State == EntityState.Added)
                {
                    entry.Entity.LastModified = DateTime.Now;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        public DbSet<LeaveAllocation> LeaveAllocations { get; set; }

        public DbSet<LeaveRequest> LeaveRequests { get; set; }

        public DbSet<LeaveType> LeaveTypes { get; set; }
    }
}