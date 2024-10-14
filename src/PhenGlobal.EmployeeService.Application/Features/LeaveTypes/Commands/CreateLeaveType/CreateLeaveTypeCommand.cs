using MediatR;
using PhenGlobal.EmployeeService.Application.Features.LeaveTypes.DTOs;
using PhenGlobal.EmployeeService.Application.Responses;

namespace PhenGlobal.EmployeeService.Application.Features.LeaveTypes.Commands.CreateLeaveType
{
    public class CreateLeaveTypeCommand : IRequest<CommandResponse<LeaveTypeDto>>
    {
        public string Name { get; set;} = default!;
        public int DefaultDays { get; set; } = default!;
    }
}