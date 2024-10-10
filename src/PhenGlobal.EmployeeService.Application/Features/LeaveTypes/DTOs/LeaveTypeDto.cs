using PhenGlobal.EmployeeService.Application.Common;

namespace PhenGlobal.EmployeeService.Application.Features.LeaveTypes.DTOs
{
    public class LeaveTypeDto : BaseDto
    {
        public string Name { get; set;} = default!;
        public int DefaultDays { get; set; } = default!;
    }
}