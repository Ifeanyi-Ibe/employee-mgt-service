using MediatR;

namespace PhenGlobal.EmployeeService.Application.Features.LeaveTypes.Commands.UpdateLeaveType
{
    public class UpdateLeaveTypeCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
        public string Name { get; set;} = default!;
        public int DefaultDays { get; set; } = default!;        
    }
}