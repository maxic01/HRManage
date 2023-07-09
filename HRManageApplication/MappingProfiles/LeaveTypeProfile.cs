using AutoMapper;
using HRManageApplication.Features.LeaveType.Commands.CreateLeaveType;
using HRManageApplication.Features.LeaveType.Commands.UpdateLeaveType;
using HRManageApplication.Features.LeaveType.Queries.GetAllLeaveTypes;
using HRManageApplication.Features.LeaveType.Queries.GetLeaveTypeDetails;
using HRManageDomain;

namespace HRManageApplication.MappingProfiles
{
    public class LeaveTypeProfile : Profile
    {
        public LeaveTypeProfile()
        {
            CreateMap<LeaveTypeDto, LeaveType>().ReverseMap();
            CreateMap<LeaveType, LeaveTypeDetailsDto>();
            CreateMap<CreateLeaveTypeCommand, LeaveType>().ReverseMap();
            CreateMap<UpdateLeaveTypeCommand, LeaveType>().ReverseMap();
        }
    }
}
