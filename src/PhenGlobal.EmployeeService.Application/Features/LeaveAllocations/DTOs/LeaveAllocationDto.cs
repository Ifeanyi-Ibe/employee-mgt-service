using PhenGlobal.EmployeeService.Application.Common;
using PhenGlobal.EmployeeService.Application.Features.LeaveTypes.DTOs;

namespace PhenGlobal.EmployeeService.Application.Features.LeaveAllocations.DTOs
{
    public class LeaveAllocationDto : BaseDto
    {
        public int NumberOfDays { get; set; } = default!;
        public int Period { get; set; } = default!;
        public LeaveTypeDto LeaveType { get; set; } = default!;
        public Guid LeaveTypeId { get; set; }

    }
}