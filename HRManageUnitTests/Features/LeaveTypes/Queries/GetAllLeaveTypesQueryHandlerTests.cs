using AutoMapper;
using HRManageApplication.Contracts.Logging;
using HRManageApplication.Contracts.Persistence;
using HRManageApplication.Features.LeaveRequest.Queries.GetAllLeaveRequests;
using HRManageApplication.Features.LeaveType.Queries.GetAllLeaveTypes;
using HRManageApplication.MappingProfiles;
using HRManageUnitTests.Mocks;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManageUnitTests.Features.LeaveTypes.Queries
{
    public class GetAllLeaveTypesQueryHandlerTests
    {
        private readonly Mock<ILeaveTypeRepository> _mockRepo;
        private readonly IMapper _mapper;
        private readonly Mock<IAppLogger<GetAllLeaveTypesQueryHandler>> _mockAppLogger;

        public GetAllLeaveTypesQueryHandlerTests()
        {
            _mockRepo = MockLeaveTypeRepository.GetLeaveTypeMockRepository();

            var mapperConfig = new MapperConfiguration(p =>
            {
                p.AddProfile<LeaveTypeProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
            _mockAppLogger = new Mock<IAppLogger<GetAllLeaveTypesQueryHandler>>();
        }

        [Fact]
        public async Task GetAllLeaveTypesTest()
        {
            var handler = new GetAllLeaveTypesQueryHandler(_mapper, _mockRepo.Object, _mockAppLogger.Object);

            var result = await handler.Handle(new GetAllLeaveTypesQuery(), CancellationToken.None);

            result.ShouldBeOfType<List<LeaveTypeDto>>();
            result.Count.ShouldBe(3);
        }
    }
}
