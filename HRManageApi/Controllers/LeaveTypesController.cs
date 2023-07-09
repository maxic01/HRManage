using HRManageApplication.Features.LeaveType.Commands.CreateLeaveType;
using HRManageApplication.Features.LeaveType.Commands.DeleteLeaveType;
using HRManageApplication.Features.LeaveType.Commands.UpdateLeaveType;
using HRManageApplication.Features.LeaveType.Queries.GetAllLeaveTypes;
using HRManageApplication.Features.LeaveType.Queries.GetLeaveTypeDetails;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HRManageApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class LeaveTypesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LeaveTypesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        
        [HttpGet]
        public async Task<List<LeaveTypeDto>> GetLeavesTypes()
        {
            var leaveTypes = await _mediator.Send(new GetAllLeaveTypesQuery());
            return leaveTypes;
        }

        
        [HttpGet("{id}")]
        public async Task<ActionResult<LeaveTypeDetailsDto>> GetLeaveTypeDetails(int id)
        {
            var leaveType = await _mediator.Send(new GetLeaveTypeDetailsQuery(id));

            return Ok(leaveType);
        }

        
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> SaveLeaveType(CreateLeaveTypeCommand leaveType)
        {
            var response = await _mediator.Send(leaveType);
            return CreatedAtAction(nameof(GetLeavesTypes), new {id = response});
        }

        
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> UpdateLeaveType(UpdateLeaveTypeCommand leaveType)
        {
            await _mediator.Send(leaveType);
            return NoContent();
        }

        
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> DeleteLeaveType(int id)
        {
            var command = new DeleteLeaveTypeCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
