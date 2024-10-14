using MediatR;
using PhenGlobal.EmployeeService.Application.Features.LeaveAllocations.DTOs;

namespace PhenGlobal.EmployeeService.Application.Features.LeaveAllocations.Commands
{
    public class CreateLeaveAllocationCommand : IRequest<LeaveAllocationDto>
    {
        public int NumberOfDays { get; set; } = default!;
        public int Period { get; set; } = default!;
        public Guid LeaveTypeId { get; set; }                
    }
}