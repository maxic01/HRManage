using AutoMapper;
using HRManageApplication.Features.LeaveRequest.Commands.CreateLeaveRequest;
using HRManageApplication.Features.LeaveRequest.Commands.UpdateLeaveRequest;
using HRManageApplication.Features.LeaveRequest.Queries.GetAllLeaveRequests;
using HRManageApplication.Features.LeaveRequest.Queries.GetLeaveRequestDetails;
using HRManageApplication.Features.LeaveType.Commands.CreateLeaveType;
using HRManageApplication.Features.LeaveType.Commands.UpdateLeaveType;
using HRManageApplication.Features.LeaveType.Queries.GetAllLeaveTypes;
using HRManageApplication.Features.LeaveType.Queries.GetLeaveTypeDetails;
using HRManageDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManageApplication.MappingProfiles
{
    public class LeaveRequestProfile : Profile
    {
        public LeaveRequestProfile()
        {
            CreateMap<LeaveRequestDto, LeaveRequest>().ReverseMap();
            CreateMap<LeaveRequest, LeaveRequestDetailsDto>();
            CreateMap<CreateLeaveRequestCommand, LeaveRequest>().ReverseMap();
            CreateMap<UpdateLeaveRequestCommand, LeaveRequest>().ReverseMap();
        }
    }
}
