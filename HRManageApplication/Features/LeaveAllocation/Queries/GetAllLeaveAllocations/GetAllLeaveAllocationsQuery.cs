using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManageApplication.Features.LeaveAllocation.Queries.GetAllLeaveAllocations
{
    public record class GetAllLeaveAllocationsQuery : IRequest<List<LeaveAllocationDto>>;
}
