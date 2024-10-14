using PhenGlobal.EmployeeService.Application.Common;
using PhenGlobal.EmployeeService.Application.Features.LeaveTypes.DTOs;

namespace PhenGlobal.EmployeeService.Application.Features.LeaveRequests.DTOs
{
    public class LeaveRequestListDto : BaseDto
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public LeaveTypeDto LeaveType { get; set; } = default!;
        public DateTime DateRequested { get; set; }
        public bool? Approved { get; set; }
    }
}