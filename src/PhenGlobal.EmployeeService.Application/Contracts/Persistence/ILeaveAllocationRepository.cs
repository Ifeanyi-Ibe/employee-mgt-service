using PhenGlobal.EmployeeService.Domain.Entities;

namespace PhenGlobal.EmployeeService.Application.Contracts.Persistence
{
    public interface ILeaveAllocationRepository : IGenericRepository<LeaveAllocation>
    {
        Task<LeaveAllocation> GetLeaveAllocationWithDetails(Guid id);
        Task<IReadOnlyCollection<LeaveAllocation>> GetLeaveAllocationsWithDetails();
    }
}