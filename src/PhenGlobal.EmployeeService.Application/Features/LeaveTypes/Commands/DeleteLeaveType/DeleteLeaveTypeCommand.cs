using MediatR;

namespace PhenGlobal.EmployeeService.Application.Features.LeaveTypes.Commands.DeleteLeaveType
{
    public class DeleteLeaveTypeCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}