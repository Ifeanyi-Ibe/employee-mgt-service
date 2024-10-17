using AutoMapper;
using MediatR;
using PhenGlobal.EmployeeService.Application.Features.LeaveAllocations.DTOs;
using PhenGlobal.EmployeeService.Application.Contracts.Persistence;
using PhenGlobal.EmployeeService.Domain.Entities;

namespace PhenGlobal.EmployeeService.Application.Features.LeaveAllocations.Commands
{
    public class CreateLeaveAllocationCommandHandler : IRequestHandler<CreateLeaveAllocationCommand, LeaveAllocationDto>
    {
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;
        private readonly IMapper _mapper;

        public CreateLeaveAllocationCommandHandler(ILeaveAllocationRepository leaveAllocationRepository, IMapper mapper)
        {
            _leaveAllocationRepository = leaveAllocationRepository;
            _mapper = mapper;
        }

        public async Task<LeaveAllocationDto> Handle(CreateLeaveAllocationCommand request, CancellationToken cancellationToken)
        {
            var leaveAllocation = _mapper.Map<LeaveAllocation>(request);
            leaveAllocation = await _leaveAllocationRepository.Add(leaveAllocation);
            return _mapper.Map<LeaveAllocationDto>(leaveAllocation);
        }
    }
}