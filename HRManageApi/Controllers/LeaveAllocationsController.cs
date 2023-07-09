using HRManageApplication.Features.LeaveAllocation.Commands.CreateLeaveAllocation;
using HRManageApplication.Features.LeaveAllocation.Commands.DeleteLeaveAllocation;
using HRManageApplication.Features.LeaveAllocation.Commands.UpdateLeaveAllocation;
using HRManageApplication.Features.LeaveAllocation.Queries.GetAllLeaveAllocations;
using HRManageApplication.Features.LeaveAllocation.Queries.GetLeaveAllocationDetails;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HRManageApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    
    public class LeaveAllocationsController : ControllerBase
    {
        private IMediator _mediator;

        public LeaveAllocationsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<LeaveAllocationDto>>> GetLeaveAllocations()
        {
            var leaveAllocations = await _mediator.Send(new GetAllLeaveAllocationsQuery());
            return Ok(leaveAllocations);
        }

        
        [HttpGet("{id}")]
        public async Task<ActionResult<LeaveAllocationsDetailsDto>> GetLeaveAllocation(int id)
        {
            var leaveAllocation = await _mediator.Send(new GetLeaveAllocationDetailsQuery { Id = id});
            return Ok(leaveAllocation);
        }

        
        
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> SaveLeaveAllocation(CreateLeaveAllocationCommand leaveAllocation)
        {
            var response = await _mediator.Send(leaveAllocation);
            return CreatedAtAction(nameof(GetLeaveAllocation), new {id = response});
        }

        
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> UpdateLeaveAllocation(UpdateLeaveAllocationCommand leaveAllocation)
        {
            await _mediator.Send(leaveAllocation);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> DeleteLeaveAllocation(int id)
        {
            var command = new DeleteLeaveAllocationCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
