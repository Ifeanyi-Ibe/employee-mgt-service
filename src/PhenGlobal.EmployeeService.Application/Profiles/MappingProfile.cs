using AutoMapper;

using PhenGlobal.EmployeeService.Domain.Entities;
using PhenGlobal.EmployeeService.Application.Features.LeaveTypes.DTOs;
using PhenGlobal.EmployeeService.Application.Features.LeaveRequests.DTOs;
using PhenGlobal.EmployeeService.Application.Features.LeaveAllocations.DTOs;

namespace PhenGlobal.EmployeeService.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<LeaveRequest, LeaveRequestDto>().ReverseMap();
            CreateMap<LeaveAllocation, LeaveAllocationDto>().ReverseMap();
            CreateMap<LeaveType, LeaveTypeDto>().ReverseMap();
            CreateMap<LeaveRequest, LeaveRequestListDto>().ReverseMap();
        }
    }
}