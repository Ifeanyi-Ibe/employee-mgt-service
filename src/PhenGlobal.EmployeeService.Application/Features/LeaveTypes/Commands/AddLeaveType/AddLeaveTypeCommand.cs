using MediatR;
using PhenGlobal.EmployeeService.Application.Features.LeaveTypes.DTOs;

namespace PhenGlobal.EmployeeService.Application.Features.LeaveTypes.Commands
{
    public class AddLeaveTypeCommand : IRequest<LeaveTypeDto>
    {
        public string Name { get; set;} = default!;
        public int DefaultDays { get; set; } = default!;
    }

}