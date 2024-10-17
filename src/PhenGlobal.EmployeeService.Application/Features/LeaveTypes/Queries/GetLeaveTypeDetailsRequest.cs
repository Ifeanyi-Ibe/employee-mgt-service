using AutoMapper;
using MediatR;
using PhenGlobal.EmployeeService.Application.Features.LeaveTypes.DTOs;
using PhenGlobal.EmployeeService.Application.Contracts.Persistence;

namespace PhenGlobal.EmployeeService.Application.Features.LeaveTypes.Queries
{
    public class GetLeaveTypeDetailsRequest : IRequest<LeaveTypeDto>
    {
        public Guid Id { get; set; }
    }

    public class GetLeaveTypeDetailsRequestHandler : IRequestHandler<GetLeaveTypeDetailsRequest, LeaveTypeDto>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;

        public GetLeaveTypeDetailsRequestHandler(ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
        {
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
        }
        public async Task<LeaveTypeDto> Handle(GetLeaveTypeDetailsRequest request, CancellationToken cancellationToken)
        {
            var leaveType = await _leaveTypeRepository.Get(request.Id);
            return _mapper.Map<LeaveTypeDto>(leaveType);
        }
    }
}