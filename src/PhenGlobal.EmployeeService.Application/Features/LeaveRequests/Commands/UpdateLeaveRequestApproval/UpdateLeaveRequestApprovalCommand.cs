using MediatR;
using PhenGlobal.EmployeeService.Application.Features.LeaveRequests.DTOs;

namespace PhenGlobal.EmployeeService.Application.Features.LeaveRequests.Commands.UpdateLeaveRequestApproval
{
    public class UpdateLeaveRequestApprovalCommand : IRequest<LeaveRequestDto>
    {
        public Guid Id { get; set; }
        public bool? Approved { get; set; }
    }
}