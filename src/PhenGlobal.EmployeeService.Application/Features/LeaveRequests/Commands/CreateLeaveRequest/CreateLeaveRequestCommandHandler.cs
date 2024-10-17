using AutoMapper;
using MediatR;
using PhenGlobal.EmployeeService.Application.Features.LeaveRequests.DTOs;
using PhenGlobal.EmployeeService.Application.Contracts.Persistence;
using PhenGlobal.EmployeeService.Domain.Entities;
using PhenGlobal.EmployeeService.Application.Contracts.Infrastructure;
using PhenGlobal.EmployeeService.Application.Models;

namespace PhenGlobal.EmployeeService.Application.Features.LeaveRequests.Commands.CreateLeaveRequest
{
    public class CreateLeaveRequestCommandHandler : IRequestHandler<CreateLeaveRequestCommand, LeaveRequestDto>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly IEmailSender _emailSender;
        private readonly IMapper _mapper;

        public CreateLeaveRequestCommandHandler(ILeaveRequestRepository leaveRequestRepository, IEmailSender emailSender, IMapper mapper)
        {
            _leaveRequestRepository = leaveRequestRepository;
            _emailSender = emailSender;
            _mapper = mapper;
        }

        public async Task<LeaveRequestDto> Handle(CreateLeaveRequestCommand request, CancellationToken cancellationToken)
        {
            var leaveRequest = _mapper.Map<LeaveRequest>(request);
            leaveRequest = await _leaveRequestRepository.Add(leaveRequest);

            var email = new Email()
            {
                To = "ken@phenglobal.com",
                Body = $"Your leave request for {request.StartDate:D} to {request.EndDate:D} has been submitted successfully.",
                Subject = "Leave Request Submitted"
            };

            try
            {
                await _emailSender.SendEmail(email);
            }
            catch (Exception exception)
            {
                System.Console.WriteLine(exception.Message);
            }

            return _mapper.Map<LeaveRequestDto>(leaveRequest);
        }
    }
}