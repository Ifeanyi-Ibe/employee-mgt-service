using AutoMapper;
using MediatR;
using PhenGlobal.EmployeeService.Application.Features.LeaveRequests.DTOs;
using PhenGlobal.EmployeeService.Application.Persistence.Contracts;
using PhenGlobal.EmployeeService.Domain.Entities;

namespace PhenGlobal.EmployeeService.Application.Features.LeaveRequests.Commands.CreateLeaveRequest
{
    public class CreateLeaveRequestCommandHandler : IRequestHandler<CreateLeaveRequestCommand, LeaveRequestDto>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly IMapper _mapper;

        public CreateLeaveRequestCommandHandler(ILeaveRequestRepository leaveRequestRepository, IMapper mapper)
        {
            _leaveRequestRepository = leaveRequestRepository;
            _mapper = mapper;
        }

        public async Task<LeaveRequestDto> Handle(CreateLeaveRequestCommand request, CancellationToken cancellationToken)
        {
            var leaveRequest = _mapper.Map<LeaveRequest>(request);
            leaveRequest = await _leaveRequestRepository.Add(leaveRequest);
            return _mapper.Map<LeaveRequestDto>(leaveRequest);
        }
    }
}