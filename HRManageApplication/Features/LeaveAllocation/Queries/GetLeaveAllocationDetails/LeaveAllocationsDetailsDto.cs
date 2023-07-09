using HRManageApplication.Features.LeaveType.Queries.GetAllLeaveTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManageApplication.Features.LeaveAllocation.Queries.GetLeaveAllocationDetails
{
    public class LeaveAllocationsDetailsDto
    {
        public int Id { get; set; }

        public int NumberOfDays { get; set; }

        public LeaveTypeDto LeaveType { get; set; }

        public int LeaveTypeId { get; set; }

        public int Period { get; set; }

    }
}
