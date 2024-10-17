using AutoMapper;
using MediatR;
using PhenGlobal.EmployeeService.Application.Features.LeaveRequests.DTOs;
using PhenGlobal.EmployeeService.Application.Contracts.Persistence;

namespace PhenGlobal.EmployeeService.Application.Features.LeaveRequests.Queries
{
    public class GetLeaveRequestDetails : IRequest<LeaveRequestDto>
    {
        public Guid Id { get; set; }
    }

    public class GetLeaveRequestDetailsHandler : IRequestHandler<GetLeaveRequestDetails, LeaveRequestDto>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly IMapper _mapper;

        public GetLeaveRequestDetailsHandler(ILeaveRequestRepository leaveRequestRepository, IMapper mapper)
        {
            _leaveRequestRepository = leaveRequestRepository;
            _mapper = mapper;
        }

        public async Task<LeaveRequestDto> Handle(GetLeaveRequestDetails request, CancellationToken cancellationToken)
        {
            var leaveRequest = await _leaveRequestRepository.GetLeaveRequestWithDetails(request.Id);
            return _mapper.Map<LeaveRequestDto>(leaveRequest);
        }
    }
}