using MediatR;
using AutoMapper;
using PhenGlobal.EmployeeService.Application.Persistence.Contracts;
using PhenGlobal.EmployeeService.Domain.Entities;
using PhenGlobal.EmployeeService.Application.Features.LeaveTypes.DTOs;

namespace PhenGlobal.EmployeeService.Application.Features.LeaveTypes.Commands.CreateLeaveType
{
    public class CreateLeaveTypeCommandHandler : IRequestHandler<CreateLeaveTypeCommand, LeaveTypeDto>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;

        public CreateLeaveTypeCommandHandler(ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
        {
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
        }
        public async Task<LeaveTypeDto> Handle(CreateLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateLeaveTypeCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if(!validationResult.IsValid) {
                throw new Exception();
            }

            var leaveType = _mapper.Map<LeaveType>(request);
            leaveType = await _leaveTypeRepository.Add(leaveType);
            return _mapper.Map<LeaveTypeDto>(leaveType);
        }
    }
}