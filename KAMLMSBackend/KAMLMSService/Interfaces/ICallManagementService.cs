using KAMLMSContracts.Entities;
using KAMLMSContracts.RequestModels;
using KAMLMSContracts.ResponseModels;

namespace KAMLMSService.Interfaces
{
    public interface ICallManagementService
    {
        int ScheduleCall(CallScheduleRequest request, string currentUser);
        IList<CallScheduleEntity> GetAllCallScheduledByPOC(string pocId);
        IList<CallScheduledResponse> GettAllCallScheduledByCompany(string companyId, int page, int take, CallFilters filter);
        IList<CallScheduleEntity> GetAllCallScheduledByStatus(int status);
        IList<CallStatusEntity> GetAllCallStatusDetails();
        void UpdateCallStatus(UpdateCallScheduleRequest request);
        IList<FollowUpResponse> GetFollowUpCallsList(string? day, string? month, string? year);
        IList<FollowUpResponse> AtRisk();
    }
}
