using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using System.Net.Http;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.Web.Virtualization;
using Microsoft.AspNetCore.Components.WebAssembly.Http;
using Microsoft.JSInterop;
using HRManageUI;
using HRManageUI.Shared;
using HRManageUI.Contracts;
using HRManageUI.Models.LeaveRequests;

namespace HRManageUI.Pages.LeaveRequests
{
    public partial class Index
    {
        [Inject] ILeaveRequestService leaveRequestService { get; set; }
        [Inject] NavigationManager NavigationManager { get; set; }
        public AdminLeaveRequestViewVM Model { get; set; } = new();

        protected async override Task OnInitializedAsync()
        {
            Model = await leaveRequestService.GetAdminLeaveRequestList();
        }

        void GoToDetails(int id)
        {
            NavigationManager.NavigateTo($"/leaverequests/details/{id}");
        }
    }
}