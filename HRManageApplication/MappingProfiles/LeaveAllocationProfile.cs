using AutoMapper;
using HRManageApplication.Features.LeaveAllocation.Commands.CreateLeaveAllocation;
using HRManageApplication.Features.LeaveAllocation.Commands.UpdateLeaveAllocation;
using HRManageApplication.Features.LeaveAllocation.Queries.GetAllLeaveAllocations;
using HRManageApplication.Features.LeaveAllocation.Queries.GetLeaveAllocationDetails;
using HRManageDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManageApplication.MappingProfiles
{
    public class LeaveAllocationProfile : Profile
    {
        public LeaveAllocationProfile()
        {
            CreateMap<LeaveAllocationDto, LeaveAllocation>().ReverseMap();
            CreateMap<LeaveAllocation, LeaveAllocationsDetailsDto>().ReverseMap();
            CreateMap<CreateLeaveAllocationCommand, LeaveAllocation>().ReverseMap();
            CreateMap<UpdateLeaveAllocationCommand, LeaveAllocation>().ReverseMap();
        }
    }
}
