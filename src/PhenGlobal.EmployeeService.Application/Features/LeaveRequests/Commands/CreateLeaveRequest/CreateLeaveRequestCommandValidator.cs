using FluentValidation;
using PhenGlobal.EmployeeService.Application.Persistence.Contracts;

namespace PhenGlobal.EmployeeService.Application.Features.LeaveRequests.Commands.CreateLeaveRequest
{
    public class CreateLeaveRequestCommandValidator : AbstractValidator<CreateLeaveRequestCommand>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;

        public CreateLeaveRequestCommandValidator(ILeaveRequestRepository leaveRequestRepository)
        {
            _leaveRequestRepository = leaveRequestRepository;

            RuleFor(p => p.StartDate)
                .LessThan(p => p.EndDate).WithMessage("{PropertyName} must be before {ComparisonValue}");

            RuleFor(p => p.EndDate)
                .GreaterThan(p => p.StartDate).WithMessage("{PropertyName} must be after {ComparisonValue}");

            RuleFor(p => p.LeaveTypeId)
                .MustAsync(async (id, token) => {
                    var leaveRequestExists = await _leaveRequestRepository.Exists(id);
                    return !leaveRequestExists;
            }).WithMessage("{PropertyName} does not exist.");
        }
    }
}