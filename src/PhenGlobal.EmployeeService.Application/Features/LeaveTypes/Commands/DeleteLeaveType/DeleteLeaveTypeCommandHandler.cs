using MediatR;
using PhenGlobal.EmployeeService.Application.Contracts.Persistence;
using PhenGlobal.EmployeeService.Application.Exceptions;
using PhenGlobal.EmployeeService.Domain.Entities;

namespace PhenGlobal.EmployeeService.Application.Features.LeaveTypes.Commands.DeleteLeaveType
{
    public class DeleteLeaveTypeCommandHandler : IRequestHandler<DeleteLeaveTypeCommand, Unit>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public DeleteLeaveTypeCommandHandler(ILeaveTypeRepository leaveTypeRepository)
        {
            _leaveTypeRepository = leaveTypeRepository;
        }

        public async Task<Unit> Handle(DeleteLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            var leaveType = await _leaveTypeRepository.Get(request.Id);

            if(leaveType is null) {
                throw new NotFoundException(nameof(LeaveType), request.Id);
            }

            await _leaveTypeRepository.Delete(leaveType);
            return Unit.Value;
        }
    }
}