using HRManageDomain;

namespace HRManageApplication.Contracts.Persistence
{
    public interface ILeaveRequestRepository : IGenericRepository<LeaveRequest>
    {
        Task<LeaveRequest> GetLeaveRequestWithDetails(int id);

        Task<List<LeaveRequest>> GetLeaveRequestsWithDetails();

        Task<List<LeaveRequest>> GetLeaveRequestWithDetails(string userId);
    }
}
