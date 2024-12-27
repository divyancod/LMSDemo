using KAMLMSContracts.Entities;
using KAMLMSContracts.RequestModels;
using KAMLMSContracts.ResponseModels;

namespace KAMLMSRepository.Interfaces
{
    public interface ICallManagementRepository
    {
        int ScheduleCall(CallScheduleEntity request);
        IList<CallScheduleEntity> GetAllCallScheduledByPOC(Guid pocId);
        IList<CallScheduledResponse> GettAllCallScheduledByCompany(Guid companyId, int page, int take, CallFilters filter);
        IList<CallScheduleEntity> GetAllCallScheduledByStatus(int status);
        IList<CallStatusEntity> GetAllCallStatusDetails();
        void UpdateCallStatus(CallScheduleEntity request);
        CallScheduleEntity GetCallStatusById(int id);
        IList<FollowUpResponse> GetFollowUpCallsList(string day, string month, string year);
        IList<FollowUpResponse> AtRisk();
        IList<FollowUpResponse> MissedCalls();
        void CancelAllCallsForLead(Guid id);
    }
}
