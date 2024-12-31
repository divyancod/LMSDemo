using KAMLMSContracts.Entities;
using KAMLMSContracts.RequestModels;
using KAMLMSContracts.ResponseModels;

namespace KAMLMSRepository.Interfaces
{
    /// <summary>
    /// Call management related db operations
    /// </summary>
    public interface ICallManagementRepository
    {
        /// <summary>
        /// Save a call
        /// </summary>
        /// <param name="request">CallScheduleEntity with call schedule details</param>
        /// <returns>Id of the call if call is scheduled successfully.</returns>
        int ScheduleCall(CallScheduleEntity request);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pocId"></param>
        /// <returns></returns>
        IList<CallScheduleEntity> GetAllCallScheduledByPOC(Guid pocId);
        IList<CallScheduledResponse> GettAllCallScheduledByCompany(Guid companyId, int page, int take, CallFilters filter);
        IList<CallScheduleEntity> GetAllCallScheduledByStatus(int status);
        IList<CallStatusEntity> GetAllCallStatusDetails();
        void UpdateCallStatus(CallScheduleEntity request);
        CallScheduleEntity GetCallStatusById(int id);
        IList<FollowUpResponse> GetFollowUpCallsList(string day, string month, string year, int page, int take);
        IList<FollowUpResponse> AtRisk(int page, int take);
        IList<FollowUpResponse> MissedCalls(int page, int take);
        void CancelAllCallsForLead(Guid id);
        void AddCallList(IList<CallScheduleEntity> request);
    }
}
