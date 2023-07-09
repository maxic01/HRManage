using HRManageApplication.Features.LeaveRequest.Commands.CancelLeaveRequest;
using HRManageApplication.Features.LeaveRequest.Commands.ChangeLeaveRequestApproval;
using HRManageApplication.Features.LeaveRequest.Commands.CreateLeaveRequest;
using HRManageApplication.Features.LeaveRequest.Commands.DeleteLeaveRequest;
using HRManageApplication.Features.LeaveRequest.Commands.UpdateLeaveRequest;
using HRManageApplication.Features.LeaveRequest.Queries.GetAllLeaveRequests;
using HRManageApplication.Features.LeaveRequest.Queries.GetLeaveRequestDetails;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HRManageApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    
    public class LeaveRequestController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LeaveRequestController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<LeaveRequestDto>>> GetLeaveRequests()
        {
            var leaveRequests = await _mediator.Send(new GetAllLeaveRequestsQuery());
            return Ok(leaveRequests);
        }

        
        [HttpGet("{id}")]
        public async Task<ActionResult<LeaveRequestDetailsDto>> GetLeaveRequestDetails(int id)
        {
            var leaveRequest = await _mediator.Send(new GetLeaveRequestDetailsQuery());
            return Ok(leaveRequest);
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> SaveLeaveRequest(CreateLeaveRequestCommand leaveRequest)
        {
            var response = await _mediator.Send(leaveRequest);
            return CreatedAtAction(nameof(SaveLeaveRequest), new { id = response });
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> UpdateLeaveRequest(UpdateLeaveRequestCommand leaveRequest)
        {
            await _mediator.Send(leaveRequest);
            return NoContent();
        }

        [HttpPut]
        [Route("CancelRequest")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> CancelRequest(CancelLeaveRequestCommand cancelLeaveRequest)
        {
            await _mediator.Send(cancelLeaveRequest);
            return NoContent();
        }

        [HttpPut]
        [Route("UpdateApproval")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> UpdateApproval(ChangeLeaveRequestApprovalCommand changeLeaveRequestApproval)
        {
            await _mediator.Send(changeLeaveRequestApproval);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> DeleteLeaveRequest(int id)
        {
            var command = new DeleteLeaveRequestCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
