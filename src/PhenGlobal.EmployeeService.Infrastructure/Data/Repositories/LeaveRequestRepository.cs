using Microsoft.EntityFrameworkCore;
using PhenGlobal.EmployeeService.Application.Exceptions;
using PhenGlobal.EmployeeService.Application.Contracts.Persistence;
using PhenGlobal.EmployeeService.Domain.Entities;

namespace PhenGlobal.EmployeeService.Infrastructure.Data.Repositories
{
    public class LeaveRequestRepository : GenericRepository<LeaveRequest>, ILeaveRequestRepository
    {
        public LeaveRequestRepository(EmployeeDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<LeaveRequest>> GetLeaveRequestsWithDetails()
        {
            return await _dbContext.LeaveRequests
                .Include(q => q.LeaveType)
                .ToListAsync();
        }

        public async Task<LeaveRequest> GetLeaveRequestWithDetails(Guid id)
        {
            return await _dbContext.LeaveRequests
                .Include(q => q.LeaveType)
                .FirstOrDefaultAsync(q => q.Id == id)

            ?? throw new NotFoundException(nameof(LeaveRequest), id);
        }

        public async Task ChangeApprovalStatus (LeaveRequest leaveRequest, bool ApprovalStatus)
        {
            leaveRequest.Approved = ApprovalStatus;

            _dbContext.Entry(leaveRequest).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

    }
}