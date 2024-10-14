using MediatR;
using PhenGlobal.EmployeeService.Application.Features.LeaveAllocations.DTOs;

namespace PhenGlobal.EmployeeService.Application.Features.LeaveAllocations.Commands.UpdateLeaveAllocation
{
    public class UpdateLeaveAllocationCommand : IRequest<LeaveAllocationDto>
    {
        public Guid Id { get; set; }
        public int NumberOfDays { get; set; } = default!;
        public int Period { get; set; } = default!;
        public Guid LeaveTypeId { get; set; }        
    }
}