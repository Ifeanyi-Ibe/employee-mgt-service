using PhenGlobal.EmployeeService.Application.Common;
using PhenGlobal.EmployeeService.Application.Features.LeaveTypes.DTOs;

namespace PhenGlobal.EmployeeService.Application.Features.LeaveRequests.DTOs
{
    public class LeaveRequestDto : BaseDto
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public LeaveTypeDto LeaveType { get; set; } = default!;
        public Guid LeaveTypeId { get; set; }
        public DateTime DateRequested { get; set; }
        public DateTime DateActioned { get; set; }
        public string RequestComments { get; set; } = default!;
        public bool? Approved { get; set; }
        public bool Cancelled { get; set; }
    }
}