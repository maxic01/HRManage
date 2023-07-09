using HRManageDomain;
using HRManagePersistence.DataBaseContext;
using Microsoft.EntityFrameworkCore;
using Shouldly;

namespace HRManagePersistenceIntegrationTests
{
    public class HRDbContextTests
    {
        private readonly HRDbContext _hrDbContext;

        public HRDbContextTests()
        {
            var dbOptions = new DbContextOptionsBuilder<HRDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;

            _hrDbContext = new HRDbContext(dbOptions);
        }

        [Fact]
        public async void Save_SetDateCreatedValue()
        {
            var leaveType = new LeaveType
            {
                Id = 1,
                DefaultDays = 10,
                Name = "Test Vacation",
            };

            await _hrDbContext.LeaveTypes.AddAsync(leaveType);
            await _hrDbContext.SaveChangesAsync();

            leaveType.DateCreated.ShouldNotBeNull();
        }

        [Fact]
        public async void Save_SetDateModifiedValue()
        {
            var leaveType = new LeaveType
            {
                Id = 1,
                DefaultDays = 10,
                Name = "Test Vacation",
            };

            await _hrDbContext.LeaveTypes.AddAsync(leaveType);
            await _hrDbContext.SaveChangesAsync();

            leaveType.DateModified.ShouldNotBeNull();
        }
    }
}