using AutoMapper;
using MediatR;
using PhenGlobal.EmployeeService.Application.Features.LeaveTypes.DTOs;
using PhenGlobal.EmployeeService.Application.Persistence.Contracts;

namespace PhenGlobal.EmployeeService.Application.Features.LeaveTypes.Queries
{
    public class GetLeaveTypesRequest : IRequest<List<LeaveTypeDto>>
    {  
    }

    public class GetLeaveTypesRequestHandler : IRequestHandler<GetLeaveTypesRequest, List<LeaveTypeDto>>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;

        public GetLeaveTypesRequestHandler(ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
        {
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
        }
        public async Task<List<LeaveTypeDto>> Handle(GetLeaveTypesRequest request, CancellationToken cancellationToken)
        {
            var leaveTypes = await _leaveTypeRepository.GetAll();
            return _mapper.Map<List<LeaveTypeDto>>(leaveTypes);
        }
    }
}