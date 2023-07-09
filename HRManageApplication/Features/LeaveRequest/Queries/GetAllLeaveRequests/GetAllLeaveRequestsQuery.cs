using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManageApplication.Features.LeaveRequest.Queries.GetAllLeaveRequests
{
    public record GetAllLeaveRequestsQuery : IRequest<List<LeaveRequestDto>>;
}
