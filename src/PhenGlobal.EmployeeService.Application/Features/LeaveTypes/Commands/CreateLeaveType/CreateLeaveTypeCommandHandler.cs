using MediatR;
using AutoMapper;
using PhenGlobal.EmployeeService.Application.Persistence.Contracts;
using PhenGlobal.EmployeeService.Domain.Entities;
using PhenGlobal.EmployeeService.Application.Features.LeaveTypes.DTOs;
using PhenGlobal.EmployeeService.Application.Exceptions;
using PhenGlobal.EmployeeService.Application.Responses;

namespace PhenGlobal.EmployeeService.Application.Features.LeaveTypes.Commands.CreateLeaveType
{
    public class CreateLeaveTypeCommandHandler : IRequestHandler<CreateLeaveTypeCommand, CommandResponse<LeaveTypeDto>>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;

        public CreateLeaveTypeCommandHandler(ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
        {
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
        }

        public async Task<CommandResponse<LeaveTypeDto>> Handle(CreateLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            var response = new CommandResponse<LeaveTypeDto>();
            var validator = new CreateLeaveTypeCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if(!validationResult.IsValid) {
                response.Success = false;
                response.Message = "Validation error";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }

            var leaveType = _mapper.Map<LeaveType>(request);
            leaveType = await _leaveTypeRepository.Add(leaveType);
            var leaveTypeDto = _mapper.Map<LeaveTypeDto>(leaveType);

            response.Success = true;
            response.Message = "Creation successful";
            response.Data = leaveTypeDto;

            return response;
        }
    }
}