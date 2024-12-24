using KAMLMSContracts.Entities;
using KAMLMSContracts.RequestModels;

namespace KAMLMSService.Interfaces
{
    public interface ICallManagementService
    {
        int ScheduleCall(CallScheduleRequest request,string currentUser);
        IList<CallScheduleEntity> GetAllCallScheduledByPOC(string pocId);
        IList<CallScheduleEntity> GettAllCallScheduledByCompany(string companyId);
        IList<CallScheduleEntity> GetAllCallScheduledByStatus(int status);
        IList<CallStatusEntity> GetAllCallStatusDetails();
    }
}
