using MediatR;
using PhenGlobal.EmployeeService.Application.Features.LeaveRequests.DTOs;

namespace PhenGlobal.EmployeeService.Application.Features.LeaveRequests.Commands.CreateLeaveRequest
{
    public class CreateLeaveRequestCommand : IRequest<LeaveRequestDto>
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Guid LeaveTypeId { get; set; }
        public string RequestComments { get; set; } = default!;        
    }
}