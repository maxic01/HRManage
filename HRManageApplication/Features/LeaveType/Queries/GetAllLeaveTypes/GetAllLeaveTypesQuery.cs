using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManageApplication.Features.LeaveType.Queries.GetAllLeaveTypes
{
    public record GetAllLeaveTypesQuery : IRequest<List<LeaveTypeDto>>;

}
