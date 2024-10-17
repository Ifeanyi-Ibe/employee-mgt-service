using PhenGlobal.EmployeeService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace PhenGlobal.EmployeeService.Application.Common.Interfaces
{
    public interface IEmployeeDbContext
    {
        DbSet<LeaveAllocation> LeaveAllocations { get; set; }
        DbSet<LeaveRequest> LeaveRequests { get; set; }
        DbSet<LeaveType> LeaveTypes { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}