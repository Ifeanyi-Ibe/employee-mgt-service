using Microsoft.EntityFrameworkCore;
using PhenGlobal.EmployeeService.Application.Exceptions;
using PhenGlobal.EmployeeService.Application.Contracts.Persistence;
using PhenGlobal.EmployeeService.Domain.Entities;

namespace PhenGlobal.EmployeeService.Infrastructure.Data.Repositories
{
    public class LeaveAllocationRepository : GenericRepository<LeaveAllocation>, ILeaveAllocationRepository
    {
        public LeaveAllocationRepository(EmployeeDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IReadOnlyCollection<LeaveAllocation>> GetLeaveAllocationsWithDetails()
        {
            return await _dbContext.LeaveAllocations
                        .Include(q => q.LeaveType)
                        .ToListAsync();
        }

        public async Task<LeaveAllocation> GetLeaveAllocationWithDetails(Guid id)
        {
            return await _dbContext.LeaveAllocations
                    .Include(q => q.LeaveType)
                    .FirstOrDefaultAsync()
                  
            ?? throw new NotFoundException(nameof(LeaveAllocation), id);
        }
    }
}