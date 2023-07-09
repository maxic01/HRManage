namespace HRManageUI.Services.Base
{
    public partial class Client : IClient
    {
        public HttpClient HttpClient
        {
            get
            {
                return _httpClient;
            }
        }

        public Task<ICollection<LeaveAllocationDto>> LeaveAllocationsAllAsync(bool isLoggedInUser)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<LeaveAllocationDto>> LeaveAllocationsAllAsync(bool isLoggedInUser, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<LeaveRequestDto>> LeaveRequestAllAsync(bool? isLoggedInUser)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<LeaveRequestDto>> LeaveRequestAllAsync(bool? isLoggedInUser, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
