using AutoMapper;
using MediatR;
using PhenGlobal.EmployeeService.Application.Exceptions;
using PhenGlobal.EmployeeService.Application.Features.LeaveAllocations.DTOs;
using PhenGlobal.EmployeeService.Application.Contracts.Persistence;
using PhenGlobal.EmployeeService.Domain.Entities;

namespace PhenGlobal.EmployeeService.Application.Features.LeaveAllocations.Commands.UpdateLeaveAllocation
{
    public class UpdateLeaveAllocationCommandHandler : IRequestHandler<UpdateLeaveAllocationCommand, LeaveAllocationDto>
    {
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;
        private readonly IMapper _mapper;

        public UpdateLeaveAllocationCommandHandler(ILeaveAllocationRepository leaveAllocationRepository, IMapper mapper)
        {
            _leaveAllocationRepository = leaveAllocationRepository;
            _mapper = mapper;
        }
        public async Task<LeaveAllocationDto> Handle(UpdateLeaveAllocationCommand request, CancellationToken cancellationToken)
        {
            var leaveAllocation = await _leaveAllocationRepository.Get(request.Id) ?? throw new NotFoundException(nameof(LeaveAllocation), request.Id);

            _mapper.Map(request, leaveAllocation);

           await _leaveAllocationRepository.Update(leaveAllocation);

            return _mapper.Map<LeaveAllocationDto>(leaveAllocation);
        }
    }
}