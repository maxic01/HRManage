using HRManageApplication.Contracts.Persistence;
using HRManageDomain;
using HRManagePersistence.DataBaseContext;
using Microsoft.EntityFrameworkCore;

namespace HRManagePersistence.Repositories
{
    public class LeaveTypeRepository : GenericRepository<LeaveType>, ILeaveTypeRepository
    {
        public LeaveTypeRepository(HRDbContext context) : base(context)
        {
        }

            public async Task<bool> IsLeaveTypeUnique(  string name)
            {
                return await _context.LeaveTypes.AnyAsync(x => x.Name == name) == false;
            }
    }
}
