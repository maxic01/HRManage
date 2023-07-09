using HRManageApplication.Contracts.Email;
using HRManageApplication.Contracts.Logging;
using HRManageApplication.Contracts.Persistence;
using HRManageApplication.Exceptions;
using HRManageApplication.Features.LeaveRequest.Commands.CreateLeaveRequest;
using HRManageApplication.Models;
using HRManageApplication.Models.Email;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManageApplication.Features.LeaveRequest.Commands.CancelLeaveRequest
{
    public class CancelLeaveRequestCommandHandler : IRequestHandler<CancelLeaveRequestCommand, Unit>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly IEmailSender _emailSender;
        private readonly IAppLogger<CancelLeaveRequestCommandHandler> _appLogger;

        public CancelLeaveRequestCommandHandler(ILeaveRequestRepository leaveRequestRepository, IEmailSender emailSender,
            IAppLogger<CancelLeaveRequestCommandHandler> appLogger)
        {
            _leaveRequestRepository = leaveRequestRepository;
            _emailSender = emailSender;
            _appLogger = appLogger;
        }

        public async Task<Unit> Handle(CancelLeaveRequestCommand request, CancellationToken cancellationToken)
        {
            var leaveRequest = await _leaveRequestRepository.GetByIdAsync(request.Id);

            if (leaveRequest == null)
            {
                throw new NotFoundException(nameof(leaveRequest), request.Id);
            }

            leaveRequest.Cancelled = true;

            try
            {
                var email = new EmailMessage
                {
                    To = string.Empty,
                    Body = $"Your leave request for {leaveRequest.StarDate:D} to {leaveRequest.EndDate:D} " +
                        $"has been cancelled successfully.",
                    Subject = "Leave Request Cancelled"

                };
                await _emailSender.SendEmail(email);
            }
            catch (Exception ex)
            {
                _appLogger.LogWarning(ex.Message);
            }

            return Unit.Value;
        }
    }
}
