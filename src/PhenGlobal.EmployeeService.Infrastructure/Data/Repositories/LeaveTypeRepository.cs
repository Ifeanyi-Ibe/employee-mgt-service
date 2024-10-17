using PhenGlobal.EmployeeService.Application.Contracts.Persistence;
using PhenGlobal.EmployeeService.Domain.Entities;

namespace PhenGlobal.EmployeeService.Infrastructure.Data.Repositories
{
    public class LeaveTypeRepository : GenericRepository<LeaveType>, ILeaveTypeRepository
    {
        public LeaveTypeRepository(EmployeeDbContext dbContext) : base(dbContext)
        {
        }
    }
}