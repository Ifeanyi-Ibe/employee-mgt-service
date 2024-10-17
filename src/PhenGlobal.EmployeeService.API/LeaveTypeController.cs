using MediatR;
using Microsoft.AspNetCore.Mvc;
using PhenGlobal.EmployeeService.Application.Features.LeaveRequests.Queries;
using PhenGlobal.EmployeeService.Application.Features.LeaveTypes.Commands.CreateLeaveType;
using PhenGlobal.EmployeeService.Application.Features.LeaveTypes.Commands.DeleteLeaveType;
using PhenGlobal.EmployeeService.Application.Features.LeaveTypes.Commands.UpdateLeaveType;
using PhenGlobal.EmployeeService.Application.Features.LeaveTypes.DTOs;
using PhenGlobal.EmployeeService.Application.Features.LeaveTypes.Queries;

namespace PhenGlobal.EmployeeService.API
{
    [ApiController]
    [Route("api/[controller]")]
    public class LeaveTypeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LeaveTypeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<LeaveTypeDto>>> GetAll()
        {
            var leaveTypes = await _mediator.Send(new GetLeaveTypesRequest());
            return Ok(leaveTypes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LeaveTypeDto>> Get(Guid id)
        {
            var leaveType = await _mediator.Send(new GetLeaveRequestDetails { Id = id });
            return Ok(leaveType);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreateLeaveTypeCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpPut]
        public async Task<ActionResult> Update([FromBody] UpdateLeaveTypeCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            await _mediator.Send(new DeleteLeaveTypeCommand {Id = id});
            return NoContent();
        }

    }
}