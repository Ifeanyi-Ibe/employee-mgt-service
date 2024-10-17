using PhenGlobal.EmployeeService.Domain.Entities;

namespace PhenGlobal.EmployeeService.Application.Contracts.Persistence
{
    public interface ILeaveRequestRepository : IGenericRepository<LeaveRequest>
    {
        Task<LeaveRequest> GetLeaveRequestWithDetails(Guid id);
        Task<List<LeaveRequest>> GetLeaveRequestsWithDetails();
        Task ChangeApprovalStatus (LeaveRequest leaveRequest, bool ApprovalStatus);
    }
}