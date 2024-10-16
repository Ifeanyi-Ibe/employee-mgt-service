using AutoMapper;
using MediatR;
using PhenGlobal.EmployeeService.Application.Exceptions;
using PhenGlobal.EmployeeService.Application.Features.LeaveRequests.DTOs;
using PhenGlobal.EmployeeService.Application.Contracts.Persistence;
using PhenGlobal.EmployeeService.Domain.Entities;

namespace PhenGlobal.EmployeeService.Application.Features.LeaveRequests.Commands.UpdateLeaveRequestApproval
{
    public class UpdateLeaveRequestApprovalCommandHandler : IRequestHandler<UpdateLeaveRequestApprovalCommand, LeaveRequestDto>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly IMapper _mapper;

        public UpdateLeaveRequestApprovalCommandHandler(ILeaveRequestRepository leaveRequestRepository, IMapper mapper)
        {
            _leaveRequestRepository = leaveRequestRepository;
            _mapper = mapper;
        }
        
        public async Task<LeaveRequestDto> Handle(UpdateLeaveRequestApprovalCommand request, CancellationToken cancellationToken)
        {
            var leaveRequest = await _leaveRequestRepository.Get(request.Id) ?? throw new NotFoundException(nameof(LeaveRequest), request.Id);
            
            leaveRequest.Approved = request.Approved;
            leaveRequest = await _leaveRequestRepository.Update(leaveRequest);
            return _mapper.Map<LeaveRequestDto>(leaveRequest);
        }
    }
}