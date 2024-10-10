using MediatR;
using AutoMapper;

using PhenGlobal.EmployeeService.Application.Persistence.Contracts;
using PhenGlobal.EmployeeService.Domain.Entities;
using PhenGlobal.EmployeeService.Application.Features.LeaveTypes.DTOs;

namespace PhenGlobal.EmployeeService.Application.Features.LeaveTypes.Commands.AddLeaveType
{
    public class AddLeaveTypeCommandHandler : IRequestHandler<AddLeaveTypeCommand, LeaveTypeDto>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;

        public AddLeaveTypeCommandHandler(ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
        {
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
        }
        public async Task<LeaveTypeDto> Handle(AddLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            var newLeaveType = new LeaveType() { Name = request.Name, DefaultDays = request.DefaultDays };
            var savedLeaveType = await _leaveTypeRepository.Add(newLeaveType);

            return _mapper.Map<LeaveTypeDto>(savedLeaveType);
        }
    }
}