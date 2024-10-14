using PhenGlobal.EmployeeService.Domain.Entities;

namespace PhenGlobal.EmployeeService.Application.Persistence.Contracts
{
    public interface ILeaveRequestRepository : IGenericRepository<LeaveRequest>
    {
        Task<LeaveRequest> GetLeaveRequestWithDetails(Guid id);
        Task<List<LeaveRequest>> GetLeaveRequestsWithDetails();
        Task<bool> Exists(Guid id);
    }
}